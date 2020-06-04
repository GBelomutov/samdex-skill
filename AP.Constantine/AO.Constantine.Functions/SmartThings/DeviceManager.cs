using AP.Constantine.Functions.Models.Responses.Payload;
using AP.Constantine.SmartThings;
using AP.Constantine.SmartThings.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP.Constantine.Functions.SmartThings
{
    public interface ISmartThingsDeviceManager
    {
        Task<List<DeviceFullInfo>> GetDevicesList();
    }

    public class DeviceManager : ISmartThingsDeviceManager
    {
        private readonly ISmartThingsClient _client;

        public DeviceManager(ISmartThingsClient client)
        {
            _client = client;
        }

        public async Task<List<DeviceFullInfo>> GetDevicesList()
        {
            var devices = await _client.GetDevices();

            return devices.Devices.Select(MapDevice).ToList();
        }

        private static DeviceFullInfo MapDevice(Device source)
        {
            return new DeviceFullInfo
            {
                Id = source.Id,
                Description = source.Label,
                Name = source.Name,
                Room = source.RoomId,
                Type = Models.Enums.DeviceType.TV
                //Capabilities = source.Components.SelectMany(x => x.Capabilities).ToDictionary(x => x.Id, x => (object)x)
            };
        }
    }
}
