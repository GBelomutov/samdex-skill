using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities.Parameters
{
    public class Mode
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        public Mode() { }

        public Mode(string value)
        {
            Value = value;
        }
    }
}
