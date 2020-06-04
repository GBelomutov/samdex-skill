using AP.Constantine.SmartThings.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AP.Constantine.SmartThings.Domain.Responses
{
    public class DevicesList
    {
        [JsonProperty("items")]
        public List<Device> Devices { get; set; }

        [JsonProperty("_links")]
        public object Links { get; set; }
    }
}
