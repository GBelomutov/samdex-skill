using AP.Constantine.Functions.Models.Capabilities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AP.Constantine.Functions.Models.Common
{
    public class YandexPayload<TDevice, TCapability>
        where TDevice : DeviceBase<TCapability>
        where TCapability : CapabilityBase
    {
        [JsonProperty("devices")]
        public List<TDevice> Devices { get; set; }
    }
}
