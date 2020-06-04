using AP.Constantine.SmartThings.Configuration;
using AP.Constantine.SmartThings.Core;
using AP.Constantine.SmartThings.Domain.Models;
using AP.Constantine.SmartThings.Domain.Responses;
using System.Threading.Tasks;

namespace AP.Constantine.SmartThings
{
    public interface ISmartThingsClient
    {
        Task<DevicesList> GetDevices();

        Task<Device> GetDeviceById(string id);
    }

    public class SmartThingsClient : ISmartThingsClient
    {
        private readonly ISmartThingsApi _api;

        public SmartThingsClient(ISmartThingsParametersProvider provider)
        {
            var config = provider.GetParameters();
            _api = ApiProvider.CreateFor(config);
        }

        public async Task<Device> GetDeviceById(string id) => await _api.GetDeviceById(id);

        public async Task<DevicesList> GetDevices() => await _api.GetDevices();
    }
}
