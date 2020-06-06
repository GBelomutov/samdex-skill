using AP.Constantine.SmartThings.Domain.Enums;
using System.Collections.Generic;

namespace AP.Constantine.SmartThings.Domain.Models
{
    public class CapabilityState
    {
        public CapabilityType Type { get; set; }

        public List<CapabilityInstance> Instances { get; set; }
    }
}
