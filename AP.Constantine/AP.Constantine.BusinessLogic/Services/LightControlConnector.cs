using AP.Constantine.BusinessLogic.Configuration;
using AP.Constantine.BusinessLogic.Core;
using AP.Constantine.BusinessLogic.Exceptions;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace AP.Constantine.BusinessLogic.Services
{
    public class LightControlConnector
    {
        private readonly INetworkConfiguratuionProvider _provider;

        public LightControlConnector(INetworkConfiguratuionProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Connects to the light with the specified IP address.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public async Task<ILightController> ConnectToLocalNetworkAsync()
        {
            // TODO: Add retries?
            var settings = _provider.GetSettings();
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await socket.ConnectAsync(settings.IpAddress, settings.Port);

            if (!socket.Connected)
            {
                throw new LightConnectionException($"Not able to connect to light with IP address {settings.IpAddress}");
            }

            var controller = new LocalNetworkLightControler(socket, settings);
            await controller.GetColorControllerData();

            return controller;
        }

        public ILightController ConnectToGlobalNetworkAsync()
        {
            var controller = new GlobalLightController(new HttpClientSingleton(), _provider);
            return controller;
        }
    }
}
