using Newtonsoft.Json;

namespace AP.Constantine.SmartThings.Domain.Models
{
    public class CapabilityInstance
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
