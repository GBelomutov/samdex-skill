using AP.Constantine.Functions.Models.Capabilities;
using AP.Constantine.Functions.Models.Common;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Requests
{
    public class DeviceUpdateRequest
    {
        [JsonProperty("payload")]
        public YandexPayload<UpdateDeviceInfo, CapabilityState> Payload { get; set; }
    }
}
