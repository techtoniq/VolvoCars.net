using System.Net.Http.Json;
using System.Text.Json.Nodes;
using VolvoCars.Common.Services;
using VolvoCars.ConnectedVehicleApi.Interfaces;

namespace VolvoCars.ConnectedVehicleApi.Services
{
    public class ConnectedVehicleApiClient : ApiClientBase, IConnectedVehicleApiClient
    {
        private readonly string _accessToken;

        public ConnectedVehicleApiClient(string vccApiKey, string apiBaseUrl, string accessToken)
            : base(vccApiKey, apiBaseUrl)
        {
            _accessToken = accessToken;
        }

        public async Task<JsonObject?> GetAllVehiclesAsync()
        {
            var client = CreateHttpClient();
            client.DefaultRequestHeaders.Add("authorization", $"Bearer {_accessToken}");

            return await client.GetFromJsonAsync<JsonObject>("vehicles");
        }
    }
}
