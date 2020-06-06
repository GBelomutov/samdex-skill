using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace AP.Constantine.SmartThings.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OwnerType
    {
        [EnumMember(Value = "USER")]
        User,
        [EnumMember(Value = "SYSTEM")]
        System,
        [EnumMember(Value = "IMPLICIT")]
        Implicit
    }
}
