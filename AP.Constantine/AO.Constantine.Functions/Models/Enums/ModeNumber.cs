using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace AP.Constantine.Functions.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ModeNumber
    {
        [EnumMember(Value = "one")]
        One,
        [EnumMember(Value = "two")]
        Two,
        [EnumMember(Value = "three")]
        Three,
        [EnumMember(Value = "four")]
        Four,
        [EnumMember(Value = "five")]
        Five,
        [EnumMember(Value = "six")]
        Six,
        [EnumMember(Value = "seven")]
        Seven,
        [EnumMember(Value = "eight")]
        Eight,
        [EnumMember(Value = "nine")]
        Nine,
        [EnumMember(Value = "ten")]
        Ten
    }
}
