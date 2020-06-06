using AP.Constantine.Functions.Models.Capabilities.Parameters;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities
{
    public class CapabilityInfoMode : CapabilityInfoBase
    {
        [JsonProperty("parameters")]
        public ModeParameter Parameter { get; set; }
        
        public CapabilityInfoMode()
        {
            Type = Enums.CapabilityType.Mode;
            ValueType = Enums.InstanceValueType.Mode;
        }
    }
}
