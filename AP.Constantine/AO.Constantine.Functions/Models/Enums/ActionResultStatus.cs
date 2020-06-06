using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace AP.Constantine.Functions.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActionResultStatus
    {
        [EnumMember(Value = "DONE")]
        Done,
        [EnumMember(Value = "ERROR")]
        Error
    }
}
