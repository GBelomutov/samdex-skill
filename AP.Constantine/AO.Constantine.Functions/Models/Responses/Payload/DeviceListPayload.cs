using AP.Constantine.Functions.Models.Responses.Payload;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Responses
{
    public class DeviceListPayload : YandexPayload<DeviceFullInfo>
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
