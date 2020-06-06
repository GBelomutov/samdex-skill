using AP.Constantine.Functions.Models.Enums;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities
{
    public class State
    {
        [JsonProperty("instance")]
        public InstanceType Instance { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
