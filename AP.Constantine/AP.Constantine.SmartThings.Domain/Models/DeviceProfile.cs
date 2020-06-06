using AP.Constantine.SmartThings.Domain.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AP.Constantine.SmartThings.Domain.Models
{
    public class DeviceProfile
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("components")]
        public List<DeviceProfileComponent> Components { get; set; }

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("owner")]
        public DeviceProfileStatus? Status { get; set; }

        [JsonProperty("restrictions")]
        public object Restrictions { get; set; }
    }
}
