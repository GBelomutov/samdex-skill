using AP.Constantine.SmartThings.Domain.Models;
using AP.Constantine.SmartThings.Domain.Requests;
using AP.Constantine.SmartThings.Domain.Responses;
using Newtonsoft.Json.Linq;
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

        /// <summary>
        ///  View a list of devices. For SmartApp tokens, the scope is restricted to the location the SmartApp is installed into.
        ///  For personal access tokens, the scope is limited to the account associated with the token.
        /// </summary>
        /// <returns>List of the device connected to user.</returns>
        [Get("v1/devices")]
        Task<DevicesList> GetDevices();

        /// <summary>
        /// Get user device info by specified identifier.
        /// </summary>
        /// <param name="deviceId">The Device ID.</param>
        /// <returns>Device info.</returns>
        [Get("v1/devices/{deviceId}")]
        Task<Device> GetDeviceById([Path] string deviceId);

        /// <summary>
        /// Read details about a device, including device attribute state. For SmartApp tokens, the scope is restricted to the location the SmartApp is installed into.
        /// For personal access tokens, the scope is limited to the account associated with the token. This scope is required to create subscriptions.
        /// </summary>
        /// <param name="deviceId">the device ID</param>
        /// <param name="componentId">The name of the component.</param>
        /// <returns>Successful return current status of device component's attributes.</returns>
        [Get("v1/devices/{deviceId}/components/{componentId}/status")]
        Task<CapabilitiesList> GetCapabilities([Path] string deviceId, [Path] string componentId);

        /// <summary>
        /// Read details about a device, including device attribute state. For SmartApp tokens, the scope is restricted to the location the SmartApp is installed into.
        /// For personal access tokens, the scope is limited to the account associated with the token. This scope is required to create subscriptions.
        /// </summary>
        /// <param name="deviceId">the device ID</param>
        /// <param name="componentId">The name of the component.</param>
        /// <param name="capabilityId">The ID of the capability.</param>
        /// <returns>Current status of the attributes of a device component's capability</returns>
        [Get("v1/devices/{deviceId}/components/{componentId}/capabilities/{capabilityId}/status")]
        Task<JObject> GetCapabilityState([Path] string deviceId, [Path] string componentId, [Path] string capabilityId);

        /// <summary>
        /// Execute commands on a device. For SmartApp tokens, the scope is restricted to the location the SmartApp is installed into.
        /// For personal access tokens, the scope is limited to the account associated with the token.
        /// </summary>
        /// <param name="deviceId">The device ID</param>
        /// <param name="request">Is command was executed successfully</param>
        /// <returns></returns>
        [Post("v1/devices/{deviceId}/commands")]
        Task SendDeviceCommand([Path] string deviceId, [Body] SendCommandRequest request);
    }
}
