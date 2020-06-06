using AP.Constantine.Shared.Extensions;
using AP.Constantine.SmartThings.Configuration;
using AP.Constantine.SmartThings.Core;
using AP.Constantine.SmartThings.Domain.Enums;
using AP.Constantine.SmartThings.Domain.Models;
using AP.Constantine.SmartThings.Domain.Requests;
using AP.Constantine.SmartThings.Domain.Responses;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AP.Constantine.SmartThings
{
    public interface ISmartThingsClient
    {
        Task<DevicesList> GetDevices();

        Task<Device> GetDeviceById(string id);

        Task<List<CapabilityState>> GetCapabilitiesByDeviceId(string id, string componentId);

        Task<CapabilityState> GetCapabilityState(string deviceId, string componentId, CapabilityType capabilityId);

        Task<bool> SendCommand(string deviceId, SendCommandRequest request);
    }

    public class SmartThingsClient : ISmartThingsClient
    {
        private const string SupportedCommandInstanceFilter = "supported";

        private readonly ISmartThingsApi _api;

        public SmartThingsClient(ISmartThingsParametersProvider provider)
        {
            var config = provider.GetParameters();
            _api = ApiProvider.CreateFor(config);
        }

        public async Task<Device> GetDeviceById(string id) => await _api.GetDeviceById(id);

        public async Task<DevicesList> GetDevices() => await _api.GetDevices();

        public async Task<List<CapabilityState>> GetCapabilitiesByDeviceId(string id, string componentId)
        {
            var rawResponse = await _api.GetCapabilities(id, componentId);
            var capabilitiesObjects = rawResponse.Properties().Select(x => GetCapabilityState((JObject)x.Value, x.Name.ToEnum<CapabilityType>())).ToList();
            return capabilitiesObjects;
        }

        public async Task<CapabilityState> GetCapabilityState(string deviceId, string componentId, CapabilityType capabilityId)
        {
            var capabilityStringId = GetAttributeOfType<EnumMemberAttribute>(capabilityId).Value;
            var response = await _api.GetCapabilityState(deviceId, componentId, capabilityStringId);

            return GetCapabilityState(response, capabilityId);
        }

        private static CapabilityState GetCapabilityState(JObject rawObject, CapabilityType capabilityId)
        {
            var instances = rawObject.Properties().Where(x => !x.Name.Contains(SupportedCommandInstanceFilter)).Select(value => new CapabilityInstance
            {
                Name = value.Name,
                Value = value.Values("value").FirstOrDefault().Value<string>()
            }).ToList();

            return new CapabilityState { Instances = instances.ToList(), Type = capabilityId };
        }

        private static T GetAttributeOfType<T>(Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public async Task<bool> SendCommand(string deviceId, SendCommandRequest request)
        {
            await _api.SendDeviceCommand(deviceId, request);
            return true;
        }
    }
}
