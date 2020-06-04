using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace AP.Constantine.SmartThings.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeviceType
    {
        [EnumMember(Value = "BLE")]
        BLE,
        [EnumMember(Value = "BLE_D2D")]
        BleD2D,

        /// <summary>
        /// Groovy device hadnler. datails are in "dth" field
        /// </summary>
        [EnumMember(Value = "DTH")]
        DTH,

        /// <summary>
        /// The device implementation is a SmartApp and the details are in the "app" field.
        /// </summary>
        [EnumMember(Value = "ENDPOINT_APP")]
        EnpointApp,

        [EnumMember(Value = "HUB")]
        HUB,
        [EnumMember(Value = "IR")]
        IR,
        [EnumMember(Value = "IR_OCF")]
        IROcf,
        [EnumMember(Value = "MQTT")]
        Mqtt,
        [EnumMember(Value = "OCF")]
        Ocf,
        [EnumMember(Value = "PENGYOU")]
        Pengyou,
        [EnumMember(Value = "VIDEO")]
        Video,
        [EnumMember(Value = "VIPER")]
        Viper,
    }
}
