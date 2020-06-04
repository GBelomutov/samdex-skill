using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Responses.Payload
{
    public class DeviceStateInfo : DeviceBase
    {
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}
