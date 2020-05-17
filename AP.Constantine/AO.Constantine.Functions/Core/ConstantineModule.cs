using AP.Constantine.Functions.Core.Utils;
using AP.Constantine.Functions.Configuration;
using AP.Constantine.BusinessLogic.Configuration;
using AP.Constantine.BusinessLogic.Core;
using AP.Constantine.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AP.Constantine.Functions.Core
{
    class ConstantineModule
    {
        /// <summary>
        /// Configure service, in here we make dependencies.
        /// </summary>
        /// <param name="serviceCollection">Service collection.</param>
        /// <returns>Service provider.</returns>
        public static ServiceProvider ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ILightController, GlobalLightController>();
            serviceCollection.AddScoped<IHttpClientSingleton, HttpClientSingleton>();
            serviceCollection.AddSingleton<INetworkConfiguratuionProvider, NetworkConfigurationProvider>();
            serviceCollection.AddTransient<ILoggerService, LoggerService>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
