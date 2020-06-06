using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities
{
    public class CapabilityState : CapabilityBase
    {
        [JsonProperty("state")]
        public State State { get; set; }
    }
}
