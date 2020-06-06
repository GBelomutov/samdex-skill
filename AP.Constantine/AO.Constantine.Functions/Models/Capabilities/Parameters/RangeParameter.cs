using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities.Parameters
{
    public class RangeParameter : ParameterBase
    {
        [JsonProperty("random_access")]
        public bool RandomAccess { get; set; }

        [JsonProperty("range")]
        public Range Range { get; set; }
    }
}
