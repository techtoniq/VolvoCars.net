using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VolvoCars.Common.Domain;
using VolvoCars.Common.Services;
using VolvoCars.LocationApi.Domain;
using VolvoCars.LocationApi.Interfaces;

namespace VolvoCars.LocationApi.Services
{
    public class LocationApiClient : ApiClientBase, ILocationApiClient
    {
        private readonly string _accessToken;

        public LocationApiClient(string vccApiKey, string apiBaseUrl, string accessToken)
            : base(vccApiKey, apiBaseUrl)
        {
            _accessToken = accessToken;
        }

        public async Task<LocationDetails> GetVehicleLocationDetailsAsync(Vin vin)
        {
            var client = CreateHttpClient();
            client.DefaultRequestHeaders.Add("authorization", $"Bearer {_accessToken}");

            var response = await client.GetStringAsync($"vehicles/{vin}/location");
            var dto = JsonConvert.DeserializeObject<JObject>(response);
            var data = dto!["data"]!.ToObject<LocationDetails>();

            return data!;
        }
    }
}
