using AP.Constantine.Functions.Models.Capabilities;
using AP.Constantine.Functions.Models.Common;
using AP.Constantine.Functions.Models.Enums;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Responses.Payload
{
    public class DeviceFullInfo : DeviceBase<CapabilityInfoBase>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("room")]
        public string Room { get; set; }

        [JsonProperty("type")]
        public DeviceType Type { get; set; }

        [JsonProperty("custom_data")]
        public object CustomData { get; set; }

        [JsonProperty("device_info")]
        public DeviceInfo DeviceInfo { get; set; }
    }
}
