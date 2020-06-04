using AP.Constantine.SmartThings.Domain.Models;
using AP.Constantine.SmartThings.Domain.Responses;
using RestEase;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AP.Constantine.SmartThings.Core
{
    [Header("User-Agent", "Constantine Smart House")]
    public interface ISmartThingsApi
    {
        /// <summary>
        /// Gets or sets the authorization.
        /// </summary>
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Get("v1/devices")]
        Task<DevicesList> GetDevices();

        [Get("v1/devices/{deviceId}")]
        Task<Device> GetDeviceById([Path] string deviceId);
    }
}
