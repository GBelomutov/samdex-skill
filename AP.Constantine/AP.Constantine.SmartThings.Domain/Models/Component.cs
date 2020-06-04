using Newtonsoft.Json;
using System.Collections.Generic;

namespace AP.Constantine.SmartThings.Domain.Models
{
    public class Component
    {
        [JsonProperty("main")]
        public string Id { get; set; }

        [JsonProperty("capabilities")]
        public List<Capability> Capabilities { get; set; }
    }
}
