using Newtonsoft.Json;

namespace AP.Constantine.SmartThings.Domain.Models
{
    public class DeviceComponent : ComponentBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
