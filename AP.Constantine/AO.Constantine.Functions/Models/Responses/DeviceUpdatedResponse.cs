using AP.Constantine.Functions.Models.Capabilities;
using AP.Constantine.Functions.Models.Common;
using AP.Constantine.Functions.Models.Responses.Payload;

namespace AP.Constantine.Functions.Models.Responses
{
    public class DeviceUpdatedResponse : YandexResponse<YandexPayload<DeviceUpdatedInfo, CapabilityState>, DeviceUpdatedInfo, CapabilityState>
    {
    }
}
