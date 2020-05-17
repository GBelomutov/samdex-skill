using Newtonsoft.Json;

namespace AP.Constantine.BusinessLogic.Models
{
    class DataCommandItem
    {
        [JsonProperty("hexData")]
        public string HexData { get; set; }

        [JsonProperty("macAddress")]
        public string MacAddress { get; set; }

        [JsonProperty("responseCount")]
        public int ResponseCount { get; set; }
    }
}
