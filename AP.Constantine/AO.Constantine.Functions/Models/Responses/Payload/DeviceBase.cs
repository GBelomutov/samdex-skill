using Newtonsoft.Json;
using System.Collections.Generic;

namespace AP.Constantine.Functions.Models.Responses
{
    public abstract class DeviceBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("capabilities")]
        public Dictionary<string, object> Capabilities { get; set; }

        [JsonProperty("properties")]
        public Dictionary<string, object> Properties { get; set; }
    }
}
