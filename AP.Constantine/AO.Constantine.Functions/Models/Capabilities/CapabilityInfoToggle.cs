using AP.Constantine.Functions.Models.Capabilities.Parameters;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities
{
    public class CapabilityInfoToggle : CapabilityInfoBase
    {
        [JsonProperty("parameters")]
        public ToggleParameter Parameter { get; set; }

        public CapabilityInfoToggle()
        {
            Type = Enums.CapabilityType.Toggle;
            ValueType = Enums.InstanceValueType.Boolean;
        }
    }
}
