using AP.Constantine.Functions.Models.Enums;
using AP.Constantine.Functions.Models.Responses.Payload;
using Newtonsoft.Json;

namespace AP.Constantine.Functions.Models.Capabilities
{
    public class State
    {
        [JsonProperty("instance")]
        public InstanceType Instance { get; set; }

        [JsonProperty("action_result", NullValueHandling = NullValueHandling.Ignore)]
        public ActionResult ActionResult { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public object Value { get; set; }
    }
}
