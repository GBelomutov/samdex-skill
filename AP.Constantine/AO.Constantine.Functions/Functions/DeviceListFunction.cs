using AP.Constantine.Functions.Models.Responses;
using System.Threading.Tasks;

namespace AP.Constantine.Functions.Functions
{
    /// <summary>
    /// Request for supplied devices list.
    /// </summary>
    public class DeviceListFunction : FunctionBase
    {
        protected override string FunctionName => "DeviceList";

        public override async Task<object> InternalRun(string body, string requestId, string userId)
        {
            var devices = await _deviceManager.GetDevicesList();
            var response = new DeviceListResponse
            {
                RequestId = requestId,
                Payload = new DeviceListPayload
                {
                    UserId = userId ?? "TEST_USER",
                    Devices = devices
                }
            };
            return response;
        }
    }
}
