using AP.Constantine.SmartThings.Domain.Enums;
using AP.Constantine.SmartThings.Domain.Models;
using System.Collections.Generic;

namespace AP.Constantine.SmartThings.Domain.Responses
{
    public class CapabilitiesList
    {
        public Dictionary<CapabilityType, CapabilityState> Capabilities { get; set; }
    }
}
