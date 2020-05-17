using AP.Constantine.BusinessLogic.Models;
using AP.Constantine.BusinessLogic.Extensions;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using AP.Constantine.BusinessLogic.Configuration;

namespace AP.Constantine.BusinessLogic.Services
{
    internal class LocalNetworkLightControler : LightControllerBase
    {
        private readonly Socket _socket;
        private readonly NetworkSettings _settings;

        internal LocalNetworkLightControler(Socket soket, NetworkSettings settings)
        {
            _socket = soket;
            _settings = settings;
        }

        /// <summary>
        /// Refreshes the internal state of this instance by gathering all necessary data from the light.
        /// </summary>
        public override async Task<ColorControllerData> GetColorControllerData()
        {
            await Send(new byte[] { 0x81, 0x8a, 0x8b, 0x96 }); // Send instruction to retrieve data later
            var result = await ReadAsync();
            return result.ToColorControllerData();
        }

        protected override Task Send(byte[] data)
        {
            var list = data.ToList();
            return Task.Run(() =>
            {
                var payload = CalculateChecksum(list).ToArray();
                _socket.Send(payload);
            });
        }

        /// <summary>
        /// Reads data from the light
        /// </summary>
        /// <returns></returns>
        private Task<byte[]> ReadAsync()
        {
            return Task.Run(() =>
            {
                var buffer = new byte[BufferSize];
                _socket.ReceiveTimeout = (int)_settings.TimeOut.TotalMilliseconds;

                var result = _socket.Receive(buffer);
                // TODO: Check result
                return buffer;
            });
        }
    }
}
