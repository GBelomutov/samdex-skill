using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AP.Constantine.BusinessLogic.Services;
using AP.Constantine.Functions.Authentication;
using AP.Constantine.Functions.Core;
using AP.Constantine.Functions.Core.Utils;
using AP.Constantine.Functions.SmartThings;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AP.Constantine.Functions
{
    public abstract class FunctionBase
    {
        private const string RequestIdHeaderKey = "X-Request-Id";
        private const string AuthTokenHeaderKey = "AuthorizationToken";

        protected readonly ISmartThingsDeviceManager _deviceManager;
        protected readonly IAuthenticationProvider _authenticationProvider;
        protected readonly ILoggerService _log;

        protected abstract string FunctionName { get; }

        public FunctionBase()
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = ConstantineModule.ConfigureServices(serviceCollection);

            _log = serviceProvider.GetService<ILoggerService>();
            _deviceManager = serviceProvider.GetService<ISmartThingsDeviceManager>();
            _authenticationProvider = serviceProvider.GetService<IAuthenticationProvider>();
            _log.Log("Functon Initialized");
        }

        public abstract Task<object> InternalRun(string body, string requestId, string userId);

        public async virtual Task<APIGatewayProxyResponse> Handle(APIGatewayProxyRequest request, ILambdaContext lambdaContext)
        {
            var requestId = GetHeaderValue(request.Headers, RequestIdHeaderKey);
            _log.Log($"Retreiving Devices List for RequestID:{requestId}");

            var authtoken = GetHeaderValue(request.Headers, AuthTokenHeaderKey);
            var user = authtoken != null ? await _authenticationProvider.GetUser(authtoken) : null;
            _log.Log($"User: { user }");

            var body = request.Body;
            _log.Log($"Request Body: { body }");

            try
            {
                var result = await InternalRun(body, requestId, user?.Username);
                var response = BuildResponse(HttpStatusCode.OK, result, requestId);
                _log.Log(response.Body);
                return response;
            }
            catch (Exception e)
            {
                _log.Log(e.ToString());
                throw;
            }
        }

        protected static string GetHeaderValue(IDictionary<string, string> headers, string headerKey) => headers?.FirstOrDefault(x => x.Key == headerKey).Value;

        private APIGatewayProxyResponse BuildResponse(HttpStatusCode code, object body, string requestId)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = (int)code,
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" },
                    { "X-Request-Id", requestId },
                    { "Access-Control-Allow-Origin", "*" }
                },
                Body = JsonConvert.SerializeObject(body)
            };
        }
    }
}
