using Amazon.Lambda.APIGatewayEvents;
using AP.Constantine.Functions.Functions;
using AP.Constantine.Functions.Models.Capabilities;
using AP.Constantine.Functions.Models.Common;
using AP.Constantine.Functions.Models.Enums;
using AP.Constantine.Functions.Models.Requests;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AP.Constantine.Functions.Tests.Integration
{
    public class SendCommandFunctionTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task HandleAudioMute(bool state)
        {
            // Arrange
            var function = new SendCommandFunction();

            var request = BuildDeviceRequest("660d0697-2ba8-4af7-9cc2-7e66a39b0fc0", CapabilityType.Toggle, InstanceType.Mute, state);
            var updateRequest = new APIGatewayProxyRequest
            {
                Body = JsonConvert.SerializeObject(request)
            };

            // Act
            var response = await function.Handle(updateRequest, null);

            // Assert
            response.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task HandleMediaPlayback(bool state)
        {
            // Arrange
            var function = new SendCommandFunction();

            var request = BuildDeviceRequest("660d0697-2ba8-4af7-9cc2-7e66a39b0fc0", CapabilityType.Toggle, InstanceType.Pause, state);
            var updateRequest = new APIGatewayProxyRequest
            {
                Body = JsonConvert.SerializeObject(request)
            };

            // Act
            var response = await function.Handle(updateRequest, null);

            // Assert
            response.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public async Task HandleSwitchOn(bool state)
        {
            // Arrange
            var function = new SendCommandFunction();

            var request = BuildDeviceRequest("660d0697-2ba8-4af7-9cc2-7e66a39b0fc0", CapabilityType.Toggle, InstanceType.SwitchOn, state);
            var updateRequest = new APIGatewayProxyRequest
            {
                Body = JsonConvert.SerializeObject(request)
            };

            // Act
            var response = await function.Handle(updateRequest, null);
            Thread.Sleep(500);
            // Assert
            response.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(ModeNumber.One)]
        [InlineData(ModeNumber.Two)]
        [InlineData(ModeNumber.Ten)]

        public async Task HandleInputSource(ModeNumber state)
        {
            // Arrange
            var function = new SendCommandFunction();

            var request = BuildDeviceRequest("660d0697-2ba8-4af7-9cc2-7e66a39b0fc0", CapabilityType.Mode, InstanceType.InputSource, state);
            var updateRequest = new APIGatewayProxyRequest
            {
                Body = JsonConvert.SerializeObject(request)
            };

            // Act
            var response = await function.Handle(updateRequest, null);

            // Assert
            response.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        [InlineData(50)]

        public async Task HandleVolumeChange(int volume)
        {
            // Arrange
            var function = new SendCommandFunction();

            var request = BuildDeviceRequest("660d0697-2ba8-4af7-9cc2-7e66a39b0fc0", CapabilityType.Range, InstanceType.Volume, volume);
            var updateRequest = new APIGatewayProxyRequest
            {
                Body = JsonConvert.SerializeObject(request)
            };

            // Act
            var response = await function.Handle(updateRequest, null);

            // Assert
            response.StatusCode.Should().Be(200);
        }

        private DeviceUpdateRequest BuildDeviceRequest(string deviceId, CapabilityType capability, InstanceType instance, object value)
        {
            return new DeviceUpdateRequest
            {
                Payload = new YandexPayload<UpdateDeviceInfo, CapabilityState>
                {
                    Devices = new List<UpdateDeviceInfo>
                    {
                    new UpdateDeviceInfo
                    {
                        Id = deviceId,
                        Capabilities = new List<CapabilityState>
                        {
                            new CapabilityState
                            {
                                Type = capability,
                                State = new State
                                {
                                    Instance = instance,
                                    Value = value
                                }
                            }
                        }
                    }
                    }
                }
            };
        }
    }
}
