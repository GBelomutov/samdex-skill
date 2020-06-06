using AP.Constantine.SmartThings.Domain.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AP.Constantine.SmartThings.Domain.Requests
{
    public class SendCommandRequest
    {
        [JsonProperty("commands")]
        public List<Command> Commands { get; set; }
    }
}
