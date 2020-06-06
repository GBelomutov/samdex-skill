using AP.Constantine.Functions.Models.Responses.Payload;
using AP.Constantine.SmartThings.Domain.Models;
using AP.Constantine.SmartThings.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace AP.Constantine.Functions.SmartThings.Extensions
{
    public static class SmartThingsDeviceExtensions
    {
        private static readonly Dictionary<Models.Enums.DeviceType, List<CapabilityType>> _deviceTypeCapabilities = new Dictionary<Models.Enums.DeviceType, List<CapabilityType>>
        {
            { Models.Enums.DeviceType.Other, new List<CapabilityType>() },
            { Models.Enums.DeviceType.TV, new List<CapabilityType> { CapabilityType.Switch, CapabilityType.TvChannel } },
            { Models.Enums.DeviceType.Light, new List<CapabilityType > { CapabilityType.Switch, CapabilityType.ColorControl } }
        };

        /// <summary>
        /// Determine Yandex.Dialogues smart house device type by its capabilities
        /// </summary>
        /// <param name="device">SmartThings device to determine</param>
        /// <returns>Yandex.Dialogues device type</returns>
        public static Models.Enums.DeviceType DetermineDeviceType(this Device source)
        {
            var capabilities = source.Components.SelectMany(x => x.Capabilities).Select(x => x.Type);
            var matchedType = _deviceTypeCapabilities
                .Where(x => x.Value.All(capability => capabilities.Contains(capability))).OrderByDescending(x => x.Value.Count).First();
            return matchedType.Key;
        }

        public static DeviceFullInfo MapDevice(this Device source)
        {
            var type = source.DetermineDeviceType();

            return new DeviceFullInfo
            {
                Id = source.Id,
                Description = source.Label,
                Name = source.Name,
                // Removed room assignment to specify it deirectly in Yandex
                //Room = source.RoomId,
                Type = type,
                Capabilities = source.Components
                .SelectMany(x => x.Capabilities)
                .Select(x => x.Type.MapCapabilityInfo())
                .Where(x => x != null).ToList()
            };
        }
    }
}
