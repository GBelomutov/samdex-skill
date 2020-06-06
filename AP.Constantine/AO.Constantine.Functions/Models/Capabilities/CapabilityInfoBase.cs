using AP.Constantine.Functions.Models.Enums;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities
{
    public abstract class CapabilityInfoBase : CapabilityBase
    {
        [JsonIgnore]
        public InstanceValueType ValueType { get; set; }

        [JsonIgnore]
        public InstanceType FunctionName { get; set; }

        [JsonProperty("retrievable")]
        public bool Retrievable { get; set; }
    }
}
