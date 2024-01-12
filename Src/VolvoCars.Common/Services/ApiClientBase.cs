using System.Net.Http.Headers;

namespace VolvoCars.Common.Services
{
    public abstract class ApiClientBase
    {
        #region Internal Fields

        /// <summary>
        /// The Volvo Cars API Key for the application.
        /// </summary>
        private readonly string _apiKey;

        /// <summary>
        /// Base Url for the Api to be called.
        /// </summary>
        private readonly string _apiBaseUrl;

        #endregion Internal Fields

        #region Ctor

        /// <summary>
        /// Base constructor for any Api Endpoint class.
        /// </summary>
        /// <param name="vccApiKey">The Volvo Cars API Key for the application.</param>
        /// <param name="apiBaseUrl">Base Url for the Api to be called.</param>
        /// <see cref="https://developer.volvocars.com/apis/docs/getting-started/"/>
        public ApiClientBase(string vccApiKey, string apiBaseUrl)
        {
            _apiKey = vccApiKey;
            _apiBaseUrl = apiBaseUrl;
        }

        #endregion Ctor

        #region Methods

        protected HttpClient CreateHttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_apiBaseUrl),
                Timeout = new TimeSpan(0, 0, 0, 0, -1)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                                    new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("vcc-api-key", _apiKey);
            //client.DefaultRequestHeaders.Add("authorization", $"Bearer {_accessToken}");

            return client;
        }

        #endregion Methods
    }
}
