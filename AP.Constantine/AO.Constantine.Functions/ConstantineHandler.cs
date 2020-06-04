using AP.Constantine.Functions.Core;
using AP.Constantine.Functions.Core.Utils;
using AP.Constantine.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using AP.Constantine.Functions.Models.Responses;
using System.Linq;
using AP.Constantine.Functions.Models.Responses.Payload;
using System.Net.Sockets;
using AP.Constantine.Functions.SmartThings;

namespace AP.Constantine.Functions
{
    public class ConstantineHandler
    {
        private const string RequestIdHeaderKey = "X-Request-Id";

        private readonly ILightController _lightConrtoller;
        private readonly ISmartThingsDeviceManager _deviceManager;
        private readonly ILoggerService _log;

        public ConstantineHandler()
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = ConstantineModule.ConfigureServices(serviceCollection);

            _log = serviceProvider.GetService<ILoggerService>();
            _lightConrtoller = serviceProvider.GetService<ILightController>();
            _deviceManager = serviceProvider.GetService<ISmartThingsDeviceManager>();
            _log.Log("Functon Initialized");
        }

        /// <summary>
        /// Avaliability check.
        /// </summary>
        public virtual APIGatewayProxyResponse HealthCheck(APIGatewayProxyRequest request, ILambdaContext lambdaContext)
        {
            var requestId = GetRequestIdFromHeaders(request.Headers);
            return BuildResponse(HttpStatusCode.OK, "i am alive", requestId);
        }

        /// <summary>
        /// Notify that 3rd party account were dettached on the Yandex side.
        /// Recall user token.
        /// </summary>
        public virtual APIGatewayProxyResponse Unlink(APIGatewayProxyRequest request, ILambdaContext lambdaContext)
        {
            var requestId = GetRequestIdFromHeaders(request.Headers);
            return BuildResponse(HttpStatusCode.OK, "dettach", requestId);
        }

        /// <summary>
        /// Request for supplied devices list.
        /// </summary>
        public virtual async Task<APIGatewayProxyResponse> DevicesList(APIGatewayProxyRequest request, ILambdaContext lambdaContext)
        {
            var requestId = GetRequestIdFromHeaders(request.Headers);
            var devices = await _deviceManager.GetDevicesList();
            var response = new DeviceListResponse
            {
                RequestId = requestId,
                Payload = new DeviceListPayload
                {
                    UserId = "22",
                    Devices = devices
                }
            };
            return BuildResponse(HttpStatusCode.OK, response, requestId);
        }

        /// <summary>
        /// Request for supplied devices list.
        /// </summary>
        public virtual APIGatewayProxyResponse DevicesQuery(APIGatewayProxyRequest request, ILambdaContext lambdaContext)
        {
            var requestId = GetRequestIdFromHeaders(request.Headers);
            var response = new DevicesStateResponse
            {
                RequestId = requestId,
                Payload = new YandexPayload<DeviceStateInfo>
                {
                    Devices = new List<DeviceStateInfo>()
                }
            };
            return BuildResponse(HttpStatusCode.OK, response, requestId);
        }

        /// <summary>
        /// Request for supplied devices list.
        /// </summary>
        public virtual async Task<APIGatewayProxyResponse> HandleDeviceCommand(APIGatewayProxyRequest request, ILambdaContext lambdaContext)
        {
            var requestId = GetRequestIdFromHeaders(request.Headers);
            try
            {
                _log.Log(request.Body);
                await _lightConrtoller.TurnOnAsync();
            }
            catch (Exception ex)
            {
                _log.Log($"Failed to process command", ex);
            }

            var response = new DeviceUpdatedResponse
            {
                RequestId = requestId,
                Payload = new YandexPayload<DeviceUpdatedInfo>
                {
                    Devices = new List<DeviceUpdatedInfo>()
                }
            };
            return BuildResponse(HttpStatusCode.OK, response, requestId);
        }

        private APIGatewayProxyResponse BuildResponse(HttpStatusCode code, object body, string requestId)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = (int)code,
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" },
                    { "X-Request-Id", requestId },
                    { "Access-Control-Allow-Origin", "*" }
                },
                Body = JsonConvert.SerializeObject(body)
            };
        }

        private static string GetRequestIdFromHeaders(IDictionary<string, string> headers)
        {
            return headers?.FirstOrDefault(x => x.Key == RequestIdHeaderKey).Value;
        }

        public async Task TurnOn()
        {
            //192.168.100.31
            //var result = await ArpRequest.SendAsync(new IPAddress(new byte[] { 192, 168, 100, 31 }));
            //MAC wired:    70:2a:d5:3d:2e:62
            //MAC wireless: 64:1c:ae:4c:a8:c7

            //MAC PC:       0c:9d:92:c2:ba:21 WORK!!!!!
            var macAddress = ParseMacAddress("0c:9d:92:c2:ba:21", ':');
            var magicPacket = GetMagicPacket(macAddress);

            using (var client = new UdpClient())
            {
                await client.SendAsync(magicPacket, 102, "constantinehome.ddns.net", 9);
            }
        }

        private byte[] GetMagicPacket(byte[] macAddress)
        {
            var packet = new List<byte> { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            for (var i = 0; i < 16; i++)
            {
                packet.AddRange(macAddress);
            }
            return packet.ToArray();
        }

        private byte[] ParseMacAddress(string macaddress, char separator)
        {
            var parts = macaddress.Split(separator);
            return parts.Select(x => Convert.ToByte(x, 16)).ToArray();
        }
    }
}
