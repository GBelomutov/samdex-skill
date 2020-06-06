using AP.Constantine.Functions.Models.Capabilities;
using AP.Constantine.Functions.Models.Common;
using AP.Constantine.Functions.Models.Requests;
using AP.Constantine.Functions.Models.Responses;
using AP.Constantine.Functions.Models.Responses.Payload;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace AP.Constantine.Functions
{
    /// <summary>
    /// Send command to device.
    /// </summary>
    public class SendCommandFunction : FunctionBase
    {
        protected override string FunctionName => "SendCommand";

        public override async Task<object> InternalRun(string body, string requestId, string userId)
        {
            var requestBody = JsonConvert.DeserializeObject<DeviceUpdateRequest>(body);

            var devices = requestBody.Payload.Devices;
            var updatedDeviceTasks = devices.Select(x => _deviceManager.UpdateDevice(x.Id, x.Capabilities));
            var updatedDevices = await Task.WhenAll(updatedDeviceTasks);

            var response = new DeviceUpdatedResponse
            {
                RequestId = requestId,
                Payload = new YandexPayload<DeviceUpdatedInfo, CapabilityState>
                {
                    Devices = updatedDevices.ToList()
                }
            };

            return response;
        }
    }
}
