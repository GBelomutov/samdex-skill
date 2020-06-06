using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace AP.Constantine.SmartThings.Domain.Enums
{
    public class CapabilityTypeConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch
            {
                return CapabilityType.Unknown;
            }
        }
    }
}
