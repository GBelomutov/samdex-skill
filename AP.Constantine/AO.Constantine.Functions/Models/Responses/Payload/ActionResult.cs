using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Responses.Payload
{
    public class ActionResult
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("error_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorCode { get; set; }

        [JsonProperty("error_message", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }
    }
}
