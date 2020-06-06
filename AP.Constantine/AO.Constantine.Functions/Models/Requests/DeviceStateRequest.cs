using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Requests
{
    public class DeviceStateRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("custom_data")]
        public object CustomData { get; set; }
    }
}
