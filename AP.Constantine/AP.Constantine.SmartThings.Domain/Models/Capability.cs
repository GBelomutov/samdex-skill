using Newtonsoft.Json;

namespace AP.Constantine.SmartThings.Domain.Models
{
    public class Capability
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }
    }
}
