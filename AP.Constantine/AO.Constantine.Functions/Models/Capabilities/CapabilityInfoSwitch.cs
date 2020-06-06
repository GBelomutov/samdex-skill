namespace AP.Constantine.Functions.Models.Capabilities
{
    public class CapabilityInfoSwitch : CapabilityInfoBase
    {
        public CapabilityInfoSwitch()
        {
            Type = Enums.CapabilityType.PowerSwitch;
            ValueType = Enums.InstanceValueType.Boolean;
        }
    }
}
