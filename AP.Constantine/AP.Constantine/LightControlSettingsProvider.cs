using AP.Constantine.BusinessLogic.Configuration;
using System;

namespace AP.Constantine
{
    public class LightControlSettingsProvider : INetworkConfiguratuionProvider
    {
        public NetworkSettings GetSettings()
        {
            return new NetworkSettings
            {
                //IpAddress = new System.Net.IPAddress(new byte[] { 192, 168, 100, 88 }),
                IpAddress = new System.Net.IPAddress(new byte[] { 47, 88, 59, 195 }),
                Port = 80,
                UseCheckSum = true,
                AuthenticationToken = "eyJ0eXAiOiJKc29uV2ViVG9rZW4iLCJhbGciOiJIUzUxMiJ9.eyJ1c2VySUQiOiJnZW9yZ2l5NDFAZ21haWwuY29tIiwidW5pSUQiOiJmY2YyY2YxY2NjNjE0MjQ0ODNhNWMyNGQ1NmNhNTQyZSIsImNkcGlkIjoiWkcwMDEiLCJzZXJ2ZXJDb2RlIjoiVVMiLCJjbGllbnRJRCI6ImMzOGM1YzA3MDAxZDAzNDl1bmtub3duIiwiZXhwaXJlRGF0ZSI6MTYwMjY4NDgxMjY3MSwicmVmcmVzaERhdGUiOjE1OTc1MDA4MTI2NzEsImxvZ2luRGF0ZSI6MTU4NzEzMjgxMjY3MX0.htR0FSrw7E6IZWCQBA9q77wJJRTmL0alEXaHcJP7U6XtWLgK3LUOdlEfkrd1anTqtw3c4_5oWv2LDwPxhsOBEw",
                MacAddress = "600194954F60",
                TimeOut = TimeSpan.FromSeconds(5)
            };
        }
    }
}
