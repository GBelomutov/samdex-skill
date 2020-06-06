using AP.Constantine.Functions.Models.Capabilities.Parameters;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities
{
    public class CapabilityInfoRange : CapabilityInfoBase
    {        
        [JsonProperty("parameters")]
        public RangeParameter Parameter { get; set; }

        public CapabilityInfoRange()
        {
            Type = Enums.CapabilityType.Range;
        }
    }
}
