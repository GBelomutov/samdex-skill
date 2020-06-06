using AP.Constantine.SmartThings.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace AP.Constantine.SmartThings.Domain.Models
{
    public class Device
    {
        [JsonProperty("deviceId")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("locationId")]
        public string LocationId { get; set; }

        [JsonProperty("roomId")]
        public string RoomId { get; set; }

        [JsonProperty("components")]
        public List<DeviceComponent> Components { get; set; }

        [JsonProperty("Profile")]
        public DeviceProfile Profile { get; set; }

        [JsonProperty("type")]
        public DeviceType DeviceType { get; set; }
    }
}
