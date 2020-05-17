using System;
using System.Net;

namespace AP.Constantine.BusinessLogic.Configuration
{
    public class NetworkSettings
    {
        public IPAddress IpAddress { get; set; }

        public int Port { get; set; }

        public TimeSpan TimeOut { get; set; }

        public bool UseCheckSum { get; set; }

        public string AuthenticationToken { get; set; }

        public string MacAddress { get; set; }
    }
}
