using AP.Constantine.Functions.Models.Capabilities;
using AP.Constantine.Functions.Models.Common;
using AP.Constantine.Functions.Models.Enums;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Responses.Payload
{
    public class DeviceStateInfo : DeviceBase<CapabilityState>
    {
        [JsonProperty("error_code", NullValueHandling = NullValueHandling.Ignore)]
        public ErrorCodes? ErrorCode { get; set; }

        [JsonProperty("error_message", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }
    }
}
