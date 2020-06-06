using Newtonsoft.Json;
using System.Collections.Generic;

namespace AP.Constantine.Functions.Models.Capabilities.Parameters
{
    public class ModeParameter: ParameterBase
    {
        [JsonProperty("modes")]
        public List<Mode> Modes { get; set; }
    }
}
