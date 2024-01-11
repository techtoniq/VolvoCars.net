using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using VolvoCars.ConnectedVehicleApi.Interfaces;

namespace VolvoCars.ConnectedVehicleApi.Services
{
    public class ConnectedVehicleApiClient : IConnectedVehicleApiClient
    {
        private readonly string _apiKey;
        private readonly string _accessToken;

        public ConnectedVehicleApiClient(string vccApiKey, string accessToken)
        {
            _apiKey = vccApiKey;
            _accessToken = accessToken;
        }

        public async Task<JsonObject?> GetAllVehiclesAsync()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://api.volvocars.com/connected-vehicle/v2/"),
                Timeout = new TimeSpan(0, 0, 0, 0, -1)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                                 new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("authorization", $"Bearer {_accessToken}");
            client.DefaultRequestHeaders.Add("vcc-api-key", _apiKey);

            return await client.GetFromJsonAsync<JsonObject>("vehicles");
        }
    }
}
