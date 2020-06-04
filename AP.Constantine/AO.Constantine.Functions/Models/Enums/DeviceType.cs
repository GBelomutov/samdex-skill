using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace AP.Constantine.Functions.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeviceType
    {
        [EnumMember(Value = "devices.types.light")]
        Light,
        [EnumMember(Value = "devices.types.socket")]
        Socket,
        [EnumMember(Value = "devices.types.switch")]
        Switch,
        [EnumMember(Value = "devices.types.thermostat")]
        Thermostat,
        [EnumMember(Value = "devices.types.thermostat.ac")]
        ThermostatAC,
        [EnumMember(Value = "devices.types.media_device")]
        MediaDevice,
        [EnumMember(Value = "devices.types.media_device.tv")]
        TV,
        [EnumMember(Value = "devices.types.media_device.tv_box")]
        TVBox,
        [EnumMember(Value = "devices.types.media_device.receiver")]
        Receiver,
        [EnumMember(Value = "devices.types.cooking")]
        Cooking,
        [EnumMember(Value = "devices.types.cooking.coffee_maker")]
        CoffeeMaker,
        [EnumMember(Value = "devices.types.cooking.kettle")]
        Kettle,
        [EnumMember(Value = "devices.types.openable")]
        Openable,
        [EnumMember(Value = "devices.types.openable.curtain")]
        Curtain,
        [EnumMember(Value = "devices.types.humidifier")]
        Humidifier,
        [EnumMember(Value = "devices.types.purifier")]
        Purifier,
        [EnumMember(Value = "devices.types.vacuum_cleaner")]
        VacuumCleaner,
        [EnumMember(Value = "devices.types.washing_machine")]
        WashingMachine,
        [EnumMember(Value = "devices.types.other")]
        Other
    }
}
