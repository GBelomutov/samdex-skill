using AP.Constantine.Functions.Models.Enums;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities
{
    public abstract class CapabilityBase
    {
        [JsonProperty("type")]
        public CapabilityType Type { get; set; }
    }
}
