using AP.Constantine.Functions.Models.Enums;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities.Parameters
{
    public abstract class ParameterBase
    {
        [JsonProperty("instance")]
        public InstanceType InstanceName { get; set; }
    }
}
