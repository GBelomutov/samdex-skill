using AP.Constantine.BusinessLogic.Configuration;
using AP.Constantine.BusinessLogic.Core;
using AP.Constantine.BusinessLogic.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AP.Constantine.BusinessLogic.Services
{
    public class GlobalLightController : LightControllerBase
    {
        private const string SendCommandEndpoint = "app/sendRequestCommand/ZG001";

        private readonly HttpClient _httpClient;
        private readonly NetworkSettings _settings;

        public GlobalLightController(IHttpClientSingleton httpClientSingleton, INetworkConfiguratuionProvider settingsProvider)
        {
            _settings = settingsProvider.GetSettings();

            var stringAddress = $"http://{_settings.IpAddress.ToString()}:{_settings.Port}";
            _httpClient = httpClientSingleton.GetClient();
            _httpClient.BaseAddress = new Uri(stringAddress);
            _httpClient.DefaultRequestHeaders.Add("token", _settings.AuthenticationToken);
        }

        public override async Task<ColorControllerData> GetColorControllerData()
        {
            var response = await SendHttpRequest(new byte[] { 0x81, 0x8a, 0x8b, 0x96 }); // Send instruction to retrieve data later
            return new ColorControllerData
            {
                HexData = new string[] { "NOT IMPLEMENTED" }
            };
        }

        protected override async Task Send(byte[] data)
        {
            await SendHttpRequest(data);
        }

        private async Task<HttpResponseMessage> SendHttpRequest(byte[] data)
        {
            var calculatedData = CalculateChecksum(data).ToArray();
            var content = new DataCommandItem
            {
                HexData = BitConverter.ToString(calculatedData).Replace("-", string.Empty),
                MacAddress = _settings.MacAddress
            };

            var serializedPayload = JsonConvert.SerializeObject(content);
            using var jsonContent = new StringContent(serializedPayload, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(SendCommandEndpoint, jsonContent);
            return response;
        }
    }
}
