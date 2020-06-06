using AP.Constantine.Functions.Models.Capabilities;
using AP.Constantine.Functions.Models.Common;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Responses.Payload
{
    public class DeviceUpdatedInfo : DeviceBase<CapabilityState>
    {
        [JsonProperty("action_result")]
        public ActionResult ActionResult { get; set; }
    }
}
