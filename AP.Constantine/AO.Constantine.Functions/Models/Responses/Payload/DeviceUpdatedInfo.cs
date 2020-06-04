using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Responses.Payload
{
    public class DeviceUpdatedInfo : DeviceBase
    {
        [JsonProperty("action_result")]
        public ActionResult ActionResult { get; set; }
    }
}
