using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VolvoCars.Common.Domain;
using VolvoCars.Common.Services;
using VolvoCars.EnergyApi.Domain;
using VolvoCars.EnergyApi.Interfaces;

namespace VolvoCars.EnergyApi.Services
{
    public class EnergyApiClient : ApiClientBase, IEnergyApiClient
    {
        private readonly string _accessToken;

        public EnergyApiClient(string vccApiKey, string apiBaseUrl, string accessToken)
            : base(vccApiKey, apiBaseUrl)
        {
            _accessToken = accessToken;
        }

        protected override HttpClient CreateHttpClient()
        {
            var client = base.CreateHttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/vnd.volvocars.api.energy.vehicledata.v1+json"));

            return client;
        }


        public async Task<RechargeStatus> GetRechargeStatusAsync(Vin vin)
        {
            var client = CreateHttpClient();
            client.DefaultRequestHeaders.Add("authorization", $"Bearer {_accessToken}");

            var response = await client.GetStringAsync($"vehicles/{vin}/recharge-status");
            var dto = JsonConvert.DeserializeObject<JObject>(response);
            var data = dto!["data"]!.ToObject<RechargeStatus>();

            return data!;
        }
    }
}
