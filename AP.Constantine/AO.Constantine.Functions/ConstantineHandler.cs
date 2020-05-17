using AP.Constantine.Functions.Core;
using AP.Constantine.Functions.Core.Utils;
using AP.Constantine.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

namespace AP.Constantine.Functions
{
    public class ConstantineHandler
    {
        private readonly ILightController _lightConrtoller;
        private readonly ILoggerService _log;

        public ConstantineHandler()
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = ConstantineModule.ConfigureServices(serviceCollection);

            _log = serviceProvider.GetService<ILoggerService>();
            _lightConrtoller = serviceProvider.GetService<ILightController>();
            _log.Log("Functon Initialized");
        }

        /// <summary>
        /// Handle for Lambda.
        /// </summary>
        public virtual async Task<string> Run(object commandParameters, ILambdaContext lambdaContext)
        {
            try
            {
                _log.Log(commandParameters.ToString());
                await _lightConrtoller.TurnOnAsync();
            }
            catch (Exception ex)
            {
                _log.Log($"Failed to process command", ex);
                throw;
            }

            return "success";
        }
    }
}
