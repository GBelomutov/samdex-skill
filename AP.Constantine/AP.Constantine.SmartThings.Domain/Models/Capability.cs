using AP.Constantine.SmartThings.Domain.Enums;
using Newtonsoft.Json;

namespace AP.Constantine.SmartThings.Domain.Models
{
    /// <summary>
    /// Define device capability
    /// </summary>
    public class Capability
    {
        /// <summary>
        /// Capability name
        /// </summary>
        [JsonProperty("id")]
        public CapabilityType Type { get; set; }

        /// <summary>
        /// Capability version
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }
    }
}
