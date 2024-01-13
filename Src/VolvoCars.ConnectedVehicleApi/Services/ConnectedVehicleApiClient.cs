using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VolvoCars.Common.Domain;
using VolvoCars.Common.Services;
using VolvoCars.ConnectedVehicleApi.Domain;
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

        public async Task<IEnumerable<Vin>> GetAllVehiclesAsync()
        {
            var client = CreateHttpClient();
            client.DefaultRequestHeaders.Add("authorization", $"Bearer {_accessToken}");

            var response = await client.GetStringAsync("vehicles");
            var dto = JsonConvert.DeserializeObject<JObject>(response);
            var data = dto!["data"]!.ToObject<IEnumerable<Vin>>();

            return data!;
        }

        public async Task<VehicleDetails> GetVehicleDetailsAsync(Vin vin)
        {
            var client = CreateHttpClient();
            client.DefaultRequestHeaders.Add("authorization", $"Bearer {_accessToken}");

            var response = await client.GetStringAsync($"vehicles/{vin}");
            var dto = JsonConvert.DeserializeObject<JObject>(response);
            var data = dto!["data"]!.ToObject<VehicleDetails>();

            return data!;
        }
    }
}
