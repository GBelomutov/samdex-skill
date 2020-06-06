using AP.Constantine.Functions.Models.Responses.Payload;
using AP.Constantine.Functions.SmartThings.Extensions;
using AP.Constantine.SmartThings;
using AP.Constantine.SmartThings.Domain.Models;
using AP.Constantine.SmartThings.Domain.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapabilityState = AP.Constantine.SmartThings.Domain.Models.CapabilityState;

namespace AP.Constantine.Functions.SmartThings
{
    public interface ISmartThingsDeviceManager
    {
        Task<List<DeviceFullInfo>> GetDevicesList();

        Task<DeviceStateInfo> GetDeviceState(string deviceId);

        Task<DeviceUpdatedInfo> UpdateDevice(string deviceId, List<Models.Capabilities.CapabilityState> states);
    }

    public class DeviceManager : ISmartThingsDeviceManager
    {
        private readonly ISmartThingsClient _client;

        public DeviceManager(ISmartThingsClient client)
        {
            _client = client;
        }

        public async Task<List<DeviceFullInfo>> GetDevicesList()
        {
            var devices = await _client.GetDevices();
            return devices.Devices.Select(x => x.MapDevice()).ToList();
        }

        public async Task<DeviceStateInfo> GetDeviceState(string deviceId)
        {
            var device = await _client.GetDeviceById(deviceId);

            var componentTasks = device.Components.Select(x => _client.GetCapabilitiesByDeviceId(deviceId, x.Id));
            var capabilities = (await Task.WhenAll(componentTasks)).SelectMany(x => x).Where(x => x.Instances?.Any() == true);

            var deviceStateInfo = new DeviceStateInfo
            {
                Id = deviceId,
                Capabilities = capabilities
                .Select(x => x.MapCapabilityState())
                .Where(x => x?.Any() == true)
                .SelectMany(x => x)
                .ToList()
            };

            return deviceStateInfo;
        }

        public async Task<DeviceUpdatedInfo> UpdateDevice(string deviceId, List<Models.Capabilities.CapabilityState> states)
        {
            var commands = states.Select(x => x.ToSmartThingsCommand("main")).ToList();
            var request = new SendCommandRequest { Commands = commands };

            var result = await _client.SendCommand(deviceId, request);

            var updatedInfo = new DeviceUpdatedInfo
            {
                Id = deviceId,
                Capabilities = states
            };
            return updatedInfo;
        }
    }
}
