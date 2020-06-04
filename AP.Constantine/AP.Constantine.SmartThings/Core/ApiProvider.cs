using AP.Constantine.SmartThings.Configuration;
using RestEase;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AP.Constantine.SmartThings.Core
{
    internal static class ApiProvider
    {
        private const string AuthType = "Bearer";

        public static ISmartThingsApi CreateFor(SmartThingsParameters parameters)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(parameters.BaseUrl),
            };

            var api = new RestClient(httpClient).For<ISmartThingsApi>();
            api.Authorization = new AuthenticationHeaderValue(AuthType, parameters.AuthenticationToken);

            return api;
        }
    }
}
