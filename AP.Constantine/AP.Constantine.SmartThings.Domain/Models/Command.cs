using AP.Constantine.SmartThings.Domain.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AP.Constantine.SmartThings.Domain.Models
{
    public class Command
    {
        [JsonProperty("component")]
        public string ComponentId { get; set; }

        [JsonProperty("capability")]
        public CapabilityType CapabilityName { get; set; }

        [JsonProperty("command")]
        public string CommandName { get; set; }

        [JsonProperty("arguments")]
        public List<object> Arguments { get; set; }
    }
}
