using AP.Constantine.Functions.Models.Responses.Payload;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Responses
{
    public abstract class YandexResponse<TPayload, TDevice>
        where TPayload : YandexPayload<TDevice>
        where TDevice : DeviceBase
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("payload")]
        public TPayload Payload { get; set; }
    }
}
