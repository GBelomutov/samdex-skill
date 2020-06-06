using AP.Constantine.Functions.Core.Utils;
using AP.Constantine.Functions.Models.Responses.Payload;
using AP.Constantine.Functions.SmartThings.Extensions;
using AP.Constantine.SmartThings;
using AP.Constantine.SmartThings.Domain.Models;
using AP.Constantine.SmartThings.Domain.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        private readonly ILoggerService _logger;

        public DeviceManager(ISmartThingsClient client, ILoggerService logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<List<DeviceFullInfo>> GetDevicesList()
        {
            var devices = await _client.GetDevices();
            return devices.Devices.Select(x => x.MapDevice()).ToList();
        }

        public async Task<DeviceStateInfo> GetDeviceState(string deviceId)
        {
            var device = await _client.GetDeviceById(deviceId);

            var componentTasks = device.Components.Select(x => SendCapabilityStateRequest(deviceId, x.Id));
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

            _logger.Log($"Sending UPDATE REQUEST to SmartThings API '\n: {request}");
            var result = await _client.SendCommand(deviceId, request);

            states.ForEach(x => x.State.Value = null);
            if (result)
            {
                states.ForEach(x => x.State.ActionResult = new ActionResult { Status = Models.Enums.ActionResultStatus.Done });
            }
            else
            {
                states.ForEach(x => x.State.ActionResult = new ActionResult { ErrorCode = Models.Enums.ErrorCodes.InternalError, ErrorMessage = "Something happens at the SmartThings API side" });
            }

            var updatedInfo = new DeviceUpdatedInfo
            {
                Id = deviceId,
                Capabilities = states
            };
            return updatedInfo;
        }

        private Task<List<CapabilityState>> SendCapabilityStateRequest(string deviceId, string componentId)
        {
            _logger.Log("Sending CAPABILITY STATE REQUEST");
            var result = _client.GetCapabilitiesByDeviceId(deviceId, componentId);
            _logger.Log($"CAPABILITY STATE RESPONSE\n: { result }");

            return result;               
        }
    }
}
