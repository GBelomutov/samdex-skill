using AP.Constantine.Functions.Models.Responses.Payload;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities
{
    public class CapabilityState : CapabilityBase
    {
        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("action_result", NullValueHandling = NullValueHandling.Ignore)]
        public ActionResult ActionResult { get; set; }
    }
}
