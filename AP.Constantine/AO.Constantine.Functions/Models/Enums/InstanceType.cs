using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace AP.Constantine.Functions.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InstanceType
    {
        #region Switch
        [EnumMember(Value = "on")]
        SwitchOn,
        #endregion


        #region Mode
        [EnumMember(Value = "cleanup_mode")]
        CleanupMode,
        [EnumMember(Value = "coffee_mode")]
        CoffeeMode,
        [EnumMember(Value = "fan_speed")]
        FanSpeed,
        [EnumMember(Value = "heat")]
        Heat,
        [EnumMember(Value = "input_source")]
        InputSource,
        [EnumMember(Value = "program")]
        Program,
        [EnumMember(Value = "swing")]
        Swing,
        [EnumMember(Value = "thermostat")]
        Thermostat,
        [EnumMember(Value = "work_speed")]
        WorkSpeed,
        #endregion

        #region Range
        [EnumMember(Value = "brightness")]
        Brightness,
        [EnumMember(Value = "channel")]
        Channel,
        [EnumMember(Value = "humidity")]
        Humidity,
        [EnumMember(Value = "open")]
        Open,
        [EnumMember(Value = "temperature")]
        Temperature,
        [EnumMember(Value = "volume")]
        Volume,
        #endregion

        #region Toggle
        [EnumMember(Value = "backlight")]
        BackLight,
        [EnumMember(Value = "controls_locked")]
        ControlsLocked,
        [EnumMember(Value = "ionization")]
        Ionization,
        [EnumMember(Value = "keep_warm")]
        KeepWarm,
        [EnumMember(Value = "mute")]
        Mute,
        [EnumMember(Value = "oscillation")]
        Oscillation,
        [EnumMember(Value = "pause")]
        Pause
        #endregion
    }
}
