using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace AP.Constantine.Functions.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CapabilityType
    {
        [EnumMember(Value = "devices.capabilities.on_off")]
        PowerSwitch,

        [EnumMember(Value = "devices.capabilities.color_setting")]
        ColorSet,

        [EnumMember(Value = "devices.capabilities.mode")]
        Mode,

        [EnumMember(Value = "devices.capabilities.range")]
        Range,

        [EnumMember(Value = "devices.capabilities.toggle")]
        Toggle
    }
}
