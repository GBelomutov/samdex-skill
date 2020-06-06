using Amazon.Lambda.APIGatewayEvents;
using AP.Constantine.Functions.Functions;
using AP.Constantine.Functions.Models.Requests;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AP.Constantine.Functions.Tests.Integration
{
    public class DevicesQueryFunctionTests
    {
        [Fact]
        public async Task Handle()
        {
            // Arrange
            var function = new DevicesQueryFunction();
            var request = new DevicesQueryRequest
            {
                Devices = new List<DeviceStateRequest>
                {
                    new DeviceStateRequest
                    {
                        Id = "660d0697-2ba8-4af7-9cc2-7e66a39b0fc0"
                    }
                }
            };
            var queryRequest = new APIGatewayProxyRequest
            {
                Body = JsonConvert.SerializeObject(request)
            };

            // Act
            var response = await function.Handle(queryRequest, null);

            // Assert
            response.StatusCode.Should().Be(200);
        }
    }
}
