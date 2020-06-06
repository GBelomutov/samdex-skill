using AP.Constantine.Functions.Models.Capabilities;
using AP.Constantine.Functions.Models.Common;
using AP.Constantine.Functions.Models.Responses.Payload;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Responses
{
    public class DeviceListPayload : YandexPayload<DeviceFullInfo, CapabilityInfoBase>
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
