using AP.Constantine.Functions.Models.Capabilities;
using AP.Constantine.Functions.Models.Common;
using AP.Constantine.Functions.Models.Requests;
using AP.Constantine.Functions.Models.Responses;
using AP.Constantine.Functions.Models.Responses.Payload;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Request for supplied devices list.
/// </summary>
namespace AP.Constantine.Functions
{
    public class DevicesQueryFunction : FunctionBase
    {
        protected override string FunctionName => "SendCommand";

        public override async Task<object> InternalRun(string body, string requestId, string userId)
        {
            var requestBody = JsonConvert.DeserializeObject<DevicesQueryRequest>(body);
            var devicesStatesTasks = requestBody.Devices
                .Select(x => _deviceManager.GetDeviceState(x.Id));
            var devicesStates = await Task.WhenAll(devicesStatesTasks);
            var response = new DevicesStateResponse
            {
                RequestId = requestId,
                Payload = new YandexPayload<DeviceStateInfo, CapabilityState>
                {
                    Devices = devicesStates.ToList()
                }
            };
            return response;
        }
    }
}
