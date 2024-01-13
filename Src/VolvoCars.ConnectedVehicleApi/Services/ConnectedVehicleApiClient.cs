using Newtonsoft.Json;
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
            var dto = JsonConvert.DeserializeObject<GetAllVehiclesDto>(response);

            return dto!.Data;
        }
    }
}
