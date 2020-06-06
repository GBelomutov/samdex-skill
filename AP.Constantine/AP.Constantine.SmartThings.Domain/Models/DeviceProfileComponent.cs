using Newtonsoft.Json;

namespace AP.Constantine.SmartThings.Domain.Models
{
    public class DeviceProfileComponent : ComponentBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
