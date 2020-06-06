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
            var components = device.Components.Select(x =>
            GetCapabilityStates(deviceId, x).Select(async x => await x).Select(x => x.Result).ToList()).SelectMany(x => x).ToList();

            var deviceStateInfo = new DeviceStateInfo
            {
                Id = deviceId,
                Capabilities = components.Select(x => x.MapCapabilityState()).SelectMany(x => x).ToList()
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
                ActionResult = new ActionResult
                {
                    Status = result ? "DONE" : "FAILURE"
                },
                Id = deviceId,
                Capabilities = states
            };
            return updatedInfo;
        }

        private List<Task<CapabilityState>> GetCapabilityStates(string deviceId, DeviceComponent component)
        {
            return component.Capabilities.Where(x => x.Type.IsYandexCompatibleCapability())
                .Select(capability => _client.GetCapabilityState(deviceId, component.Id, capability.Type)).ToList();
        }
    }
}
