using AP.Constantine.Functions.Core.Utils;
using AP.Constantine.Functions.Configuration;
using AP.Constantine.BusinessLogic.Configuration;
using AP.Constantine.BusinessLogic.Core;
using AP.Constantine.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;
using AP.Constantine.SmartThings;
using AP.Constantine.SmartThings.Configuration;
using AP.Constantine.Functions.SmartThings;
using AP.Constantine.Functions.Authentication;

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
            serviceCollection.AddScoped<IAuthenticationProvider, AuthenticationProvider>();

            serviceCollection.AddScoped<IWakeOnLanService, WakeOnLanService>();

            // SmartThings Module
            serviceCollection.AddScoped<ISmartThingsClient, SmartThingsClient>();
            serviceCollection.AddScoped<ISmartThingsParametersProvider, SmartThingsConfigurationProvider>();
            serviceCollection.AddScoped<ISmartThingsDeviceManager, DeviceManager>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
