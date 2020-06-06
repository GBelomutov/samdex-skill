using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace AP.Constantine.SmartThings.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeviceProfileStatus
    {
        [EnumMember(Value = "DEVELOPMENT")]
        Development,

        [EnumMember(Value = "PUBLISHED")]
        Published
    }
}
