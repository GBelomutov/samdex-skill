using AP.Constantine.Functions.Models.Capabilities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AP.Constantine.Functions.Models.Common
{
    public abstract class DeviceBase<T> where T : CapabilityBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("capabilities", NullValueHandling = NullValueHandling.Ignore)]
        public List<T> Capabilities { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Properties { get; set; }
    }
}
