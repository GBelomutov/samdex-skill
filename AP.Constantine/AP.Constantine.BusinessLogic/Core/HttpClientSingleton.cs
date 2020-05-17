using System.Net.Http;

namespace AP.Constantine.BusinessLogic.Core
{
    /// <summary>
    /// An abstraction for HttpClientSingleton
    /// </summary>
    public interface IHttpClientSingleton
    {
        /// <summary>
        /// Gets the instace of HttpClient
        /// </summary>
        HttpClient GetClient();
    }

    /// <inheritdoc/>
    public class HttpClientSingleton : IHttpClientSingleton
    {
        private static readonly HttpClient _instance = new HttpClient();

        /// <inheritdoc/>
        public HttpClient GetClient()
        {
            return _instance;
        }
    }
}
