using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities.Parameters
{
    public class Range
    {
        [JsonProperty("max")]
        public int MaxValue { get; set; }

        [JsonProperty("min")]
        public int MinValue { get; set; }

        [JsonProperty("precision")]
        public int Precision { get; set; }
    }
}
