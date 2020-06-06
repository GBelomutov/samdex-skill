using AP.Constantine.Functions.Models.Capabilities;
using AP.Constantine.Functions.Models.Common;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Responses
{
    public abstract class YandexResponse<TPayload, TDevice, TCapability>
        where TPayload : YandexPayload<TDevice, TCapability>
        where TDevice : DeviceBase<TCapability>
        where TCapability : CapabilityBase
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("payload")]
        public TPayload Payload { get; set; }
    }
}
