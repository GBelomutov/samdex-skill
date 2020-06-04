using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Common
{
    public class DeviceInfo
    {
        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("hw_version")]
        public string HwVersion { get; set; }

        [JsonProperty("sw_version")]
        public string SwVersion { get; set; }
    }
}
