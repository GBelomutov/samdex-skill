using Newtonsoft.Json;
using System.Collections.Generic;

namespace AP.Constantine.Functions.Models.Responses.Payload
{
    public class YandexPayload<T> where T : DeviceBase
    {
        [JsonProperty("devices")]
        public List<T> Devices { get; set; }
    }
}
