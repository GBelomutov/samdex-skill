using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace AP.Constantine.Functions.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ErrorCodes
    {
        [EnumMember(Value = "DEVICE_UNREACHABLE")]
        DeviceUnreachable,
        [EnumMember(Value = "DEVICE_BUSY")]
        DeviceBusy,
        [EnumMember(Value = "DEVICE_NOT_FOUND")]
        DeviceNotFound,
        [EnumMember(Value = "INTERNAL_ERROR")]
        InternalError
    }
}
