using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace AP.Constantine.SmartThings.Domain.Enums
{
    [JsonConverter(typeof(CapabilityTypeConverter))]
    public enum CapabilityType
    {
        [EnumMember(Value = "unknown")]
        Unknown = 0,

        #region Standard capabilities
        [EnumMember(Value = "accelerationSensor")]
        AccelerationSensor,

        [EnumMember(Value = "activityLightingMode")]
        ActivityLightningMode,

        [EnumMember(Value = "airConditionerMode")]
        AirConditionerMode,

        [EnumMember(Value = "airQualitySensor")]
        AirQualitySensor,

        [EnumMember(Value = "alarm")]
        Alarm,

        [EnumMember(Value = "audioMute")]
        AudioMute,

        [EnumMember(Value = "audioVolume")]
        AudioVolume,

        [EnumMember(Value = "battery")]
        Battery,

        [EnumMember(Value = "bodyMassIndexMeasurement")]
        BodyMassIndexMeasurement,

        [EnumMember(Value = "bodyWeightMeasurement")]
        BodyWeightMeasurement,

        [EnumMember(Value = "carbonDioxideMeasurement")]
        CarbonDioxideMeasurement,

        [EnumMember(Value = "carbonMonoxideDetector")]
        CarbonMonoxideDetector,

        [EnumMember(Value = "carbonMonoxideMeasurement")]
        CarbonMonoxideMeasurement,

        [EnumMember(Value = "colorControl")]
        ColorControl,

        [EnumMember(Value = "colorTemperature")]
        ColorTemperature,

        [EnumMember(Value = "contactSensor")]
        ContactSensor,

        [EnumMember(Value = "dishwasherMode")]
        DishwasherMode,

        [EnumMember(Value = "dishwasherOperatingState")]
        DishwasherOperatingState,

        [EnumMember(Value = "doorControl")]
        DoorControl,

        [EnumMember(Value = "dryerMode")]
        DryerMode,

        [EnumMember(Value = "dryerOperatingState")]
        DryerOperatingState,

        [EnumMember(Value = "dustSensor")]
        DustSensor,

        [EnumMember(Value = "energyMeter")]
        EnergyMeter,

        [EnumMember(Value = "equivalentCarbonDioxideMeasurement")]
        EquivalentCarbonDioxideMeasurement,

        [EnumMember(Value = "fanSpeed")]
        FanSpeed,

        [EnumMember(Value = "filterStatus")]
        FilterStatus,

        [EnumMember(Value = "formaldehydeMeasurement")]
        FormaldehydeMeasurement,

        [EnumMember(Value = "garageDoorControl")]
        GarageDoorControl,

        [EnumMember(Value = "illuminanceMeasurement")]
        IlluminanceMeasurement,

        [EnumMember(Value = "infraredLevel")]
        InfraredLevel,

        [EnumMember(Value = "lock")]
        Lock,

        [EnumMember(Value = "mediaInputSource")]
        MediaInputSource,

        [EnumMember(Value = "mediaPlaybackRepeat")]
        MediaPlaybackRepeat,

        [EnumMember(Value = "mediaPlaybackShuffle")]
        MediaPlaybackShuffle,

        [EnumMember(Value = "mediaPlayback")]
        MediaPlayback,

        [EnumMember(Value = "motionSensor")]
        MotionSensor,

        [EnumMember(Value = "odorSensor")]
        OdorSensor,

        [EnumMember(Value = "ovenMode")]
        OvenMode,

        [EnumMember(Value = "ovenOperatingState")]
        OvenOperatingState,

        [EnumMember(Value = "ovenSetpoint")]
        OvenSetpoint,

        [EnumMember(Value = "powerMeter")]
        PowerMeter,

        [EnumMember(Value = "powerSource")]
        PowerSource,

        [EnumMember(Value = "presenceSensor")]
        PresenceSensor,

        [EnumMember(Value = "rapidCooling")]
        RapidCooling,

        [EnumMember(Value = "refrigerationSetpoint")]
        RefrigerationSetpoint,

        [EnumMember(Value = "relativeHumidityMeasurement")]
        RelativeHumidityMeasurement,

        [EnumMember(Value = "robotCleanerCleaningMode")]
        RobotCleanerCleaningMode,

        [EnumMember(Value = "robotCleanerMovement")]
        RobotCleanerMovement,

        [EnumMember(Value = "robotCleanerTurboMode")]
        RobotCleanerTurboMode,

        [EnumMember(Value = "signalStrength")]
        SignalStrength,

        [EnumMember(Value = "smokeDetector")]
        SmokeDetector,

        [EnumMember(Value = "soundSensor")]
        SoundSensor,

        [EnumMember(Value = "switchLevel")]
        SwitchLevel,

        [EnumMember(Value = "switch")]
        Switch,

        [EnumMember(Value = "tamperAlert")]
        TamperAlert,

        [EnumMember(Value = "temperatureMeasurement")]
        TemperatureMeasurement,

        [EnumMember(Value = "thermostatCoolingSetpoint")]
        ThermostatCoolingSetpoint,

        [EnumMember(Value = "thermostatFanMode")]
        ThermostatFanMode,

        [EnumMember(Value = "thermostatHeatingSetpoint")]
        ThermostatHeatingSetpoint,

        [EnumMember(Value = "thermostatMode")]
        ThermostatMode,

        [EnumMember(Value = "thermostatOperatingState")]
        ThermostatOperatingState,

        [EnumMember(Value = "thermostatSetpoint")]
        ThermostatSetpoint,

        [EnumMember(Value = "tone")]
        Tone,

        [EnumMember(Value = "tvChannel")]
        TvChannel,

        [EnumMember(Value = "tvocMeasurement")]
        TvocMeasurement,

        [EnumMember(Value = "ultravioletIndex")]
        UltravioletIndex,

        [EnumMember(Value = "valve")]
        Valve,

        [EnumMember(Value = "voltageMeasurement")]
        VoltageMeasurement,

        [EnumMember(Value = "washerMode")]
        WasherMode,

        [EnumMember(Value = "washerOperatingState")]
        WasherOperatingState,

        [EnumMember(Value = "waterSensor")]
        WaterSensor,

        [EnumMember(Value = "windowShade")]
        WindowShade,
        #endregion

        #region Custom capabilities
        [EnumMember(Value = "custom.launchapp")]
        LaunchApp,

        [EnumMember(Value = "custom.error")]
        Error,

        [EnumMember(Value = "custom.soundMode")]
        SoundMode,
        #endregion

        #region Samsung capabilities
        [EnumMember(Value = "custom.picturemode")]
        PictureMode

        #endregion
    }
}
