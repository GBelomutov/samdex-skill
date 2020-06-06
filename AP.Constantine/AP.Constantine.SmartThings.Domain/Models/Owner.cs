using AP.Constantine.SmartThings.Domain.Enums;
using Newtonsoft.Json;

namespace AP.Constantine.SmartThings.Domain.Models
{
    public class Owner
    {
        [JsonProperty("ownerId")]
        public string Id { get; set; }

        [JsonProperty("ownerType")]
        public OwnerType Type { get; set; }
    }
}
