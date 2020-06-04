using Newtonsoft.Json;

namespace AP.Constantine.SmartThings.Domain.Models
{
    public class DeviceProfile
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
