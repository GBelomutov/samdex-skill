using AP.Constantine.SmartThings.Configuration;

namespace AP.Constantine.Functions.Configuration
{
    public class SmartThingsConfigurationProvider : ISmartThingsParametersProvider
    {
        public SmartThingsParameters GetParameters()
        {
            return new SmartThingsParameters
            {
                AuthenticationToken = "059fda0e-ed3a-43c6-942e-931e37a00770",
                BaseUrl = "https://api.smartthings.com"
            };
        }
    }
}
