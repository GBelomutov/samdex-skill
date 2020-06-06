using Newtonsoft.Json;
using System.Collections.Generic;

namespace AP.Constantine.SmartThings.Domain.Models
{
    public abstract class ComponentBase
    {
        [JsonProperty("capabilities")]
        public List<Capability> Capabilities { get; set; }
    }
}
