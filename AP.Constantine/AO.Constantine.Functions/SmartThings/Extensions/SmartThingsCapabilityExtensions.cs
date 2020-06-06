using AP.Constantine.Functions.Models.Capabilities;
using AP.Constantine.Functions.Models.Enums;
using AP.Constantine.SmartThings.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using CapabilityState = AP.Constantine.SmartThings.Domain.Models.CapabilityState;
using CapabilityType = AP.Constantine.SmartThings.Domain.Enums.CapabilityType;

namespace AP.Constantine.Functions.SmartThings.Extensions
{
    public static class SmartThingsCapabilityExtensions
    {
        private static readonly Dictionary<string, ModeNumber> _mediaInputValueTypes = new Dictionary<string, ModeNumber>
        {
            { "digitalTv", ModeNumber.Ten },
            { "HDMI1", ModeNumber.One },
            { "HDMI2", ModeNumber.Two },
            { "HDMI3", ModeNumber.Three }
        };

        private static readonly Dictionary<CapabilityType, Func<CapabilityInfoBase>> _capabilityTypeInfoCreators = new Dictionary<CapabilityType, Func<CapabilityInfoBase>>
        {
            { CapabilityType.Switch, CreateSwitchCapability },
            { CapabilityType.AudioMute, CreateAudioMuteCapability },
            { CapabilityType.MediaPlayback, CreatePauseCapability },
            { CapabilityType.MediaInputSource, CreateInputSourceModeCapability },
            { CapabilityType.AudioVolume, CreateAudioVolumeCapability },
        };

        private static readonly Dictionary<InstanceType, CapabilityType> _instanceTypeCapabilityDefenitions = new Dictionary<InstanceType, CapabilityType>
        {
            { InstanceType.SwitchOn, CapabilityType.Switch },
            { InstanceType.Mute, CapabilityType.AudioMute },
            { InstanceType.Pause, CapabilityType.MediaPlayback },
            { InstanceType.InputSource, CapabilityType.MediaInputSource},
            { InstanceType.Volume, CapabilityType.AudioVolume },
        };

        public static Command ToSmartThingsCommand(this Models.Capabilities.CapabilityState source, string componentId)
        {
            var command = new Command
            {
                CapabilityName = _instanceTypeCapabilityDefenitions[source.State.Instance],
                ComponentId = componentId,
            };
            var state = source.State;
            switch (state.Instance)
            {
                case InstanceType.SwitchOn:
                    command.CommandName = (bool)state.Value ? "on" : "off";
                    break;
                case InstanceType.Mute:
                    command.CommandName = "setMute"; command.Arguments = new List<object> { (bool)state.Value ? "muted" : "unmuted" };
                    break;
                case InstanceType.Pause:
                    command.CommandName = (bool)state.Value ? "play" : "pause";
                    break;
                case InstanceType.Volume:
                    command.CommandName = "setVolume"; command.Arguments = new List<object> { state.Value };
                    break;
                case InstanceType.InputSource:
                    command.CommandName = "setInputSource";
                    command.Arguments = new List<object> {
                        _mediaInputValueTypes
                        .FirstOrDefault(x => x.Value == state.Value.ToString().ToEnum<ModeNumber>())
                        .Key
                    }; break;
            }
            return command;
        }

        public static List<Models.Capabilities.CapabilityState> MapCapabilityState(this CapabilityState source)
        {
            var info = source.Type.MapCapabilityInfo();

            var capabilities = source.Instances.Select(x => new Models.Capabilities.CapabilityState
            {
                Type = info.Type,
                State = new State
                {
                    Instance = info.FunctionName,
                    Value = x.Value.ToYandexValue(x.Name)
                }
            });
            return capabilities.ToList();
        }

        public static bool IsYandexCompatibleCapability(this CapabilityType source) => source.MapCapabilityInfo() != null;

        public static CapabilityInfoBase MapCapabilityInfo(this CapabilityType source)
        {
            if (_capabilityTypeInfoCreators.TryGetValue(source, out var capabilityCreator))
            {
                return capabilityCreator();
            }
            return null;
        }

        private static object ToYandexValue(this object source, string instanceType)
        {
            return instanceType switch
            {
                "volume" => Convert.ToInt32(source),
                "inputSource" => _mediaInputValueTypes[source.ToString()],
                "playbackStatus" => source?.ToString() == "pause",
                "mute" => source.ToString() != "unmute",
                "switch" => source.ToString() == "on",
                _ => false,
            };
        }

        private static CapabilityInfoSwitch CreateSwitchCapability() => new CapabilityInfoSwitch { FunctionName = InstanceType.SwitchOn };

        private static CapabilityInfoToggle CreateAudioMuteCapability() => new CapabilityInfoToggle { FunctionName = InstanceType.Mute, Parameter = new Models.Capabilities.Parameters.ToggleParameter { InstanceName = InstanceType.Mute } };

        private static CapabilityInfoToggle CreatePauseCapability() => new CapabilityInfoToggle { FunctionName = InstanceType.Pause, Parameter = new Models.Capabilities.Parameters.ToggleParameter { InstanceName = InstanceType.Pause } };

        private static CapabilityInfoMode CreateInputSourceModeCapability() => new CapabilityInfoMode
        {
            FunctionName = InstanceType.InputSource,
            Parameter = new Models.Capabilities.Parameters.ModeParameter
            {
                InstanceName = InstanceType.InputSource,
                Modes = new List<Models.Capabilities.Parameters.Mode>
                {
                    new Models.Capabilities.Parameters.Mode("one"),
                    new Models.Capabilities.Parameters.Mode("two"),
                    new Models.Capabilities.Parameters.Mode("three"),
                }
            }
        };

        private static CapabilityInfoRange CreateAudioVolumeCapability() => new CapabilityInfoRange
        {
            FunctionName = InstanceType.Volume,
            Parameter = new Models.Capabilities.Parameters.RangeParameter
            {
                InstanceName = InstanceType.Volume,
                RandomAccess = true,
                Range = new Models.Capabilities.Parameters.Range
                {
                    MaxValue = 100,
                    MinValue = 0,
                    Precision = 1
                }
            }
        };
    }
}
