using Newtonsoft.Json;
using System.Collections.Generic;

namespace AP.Constantine.Functions.Models.Requests
{
    public class DevicesQueryRequest
    {
        [JsonProperty("devices")]
        public List<DeviceStateRequest> Devices { get; set; }
    }
}
