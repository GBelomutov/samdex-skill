using Amazon.Lambda.APIGatewayEvents;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace AP.Constantine.Functions.Tests.Integration
{
    public class DevicesListFunctionTests
    {
        [Fact]
        public async Task Handle()
        {
            // Arrange
            var function = new DeviceListFunction();
            var request = new APIGatewayProxyRequest();

            // Act
            var response = await function.Handle(request, null);

            // Assert
            response.StatusCode.Should().Be(200);
        }
    }
}
