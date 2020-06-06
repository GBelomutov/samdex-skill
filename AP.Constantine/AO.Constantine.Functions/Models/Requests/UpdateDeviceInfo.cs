using AP.Constantine.Functions.Models.Capabilities;
using AP.Constantine.Functions.Models.Common;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Requests
{
    public class UpdateDeviceInfo : DeviceBase<CapabilityState>
    {
        [JsonProperty("custom_data")]
        public object CustomData { get; set; }
    }
}
