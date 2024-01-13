using FluentAssertions;
using Microsoft.Extensions.Configuration;
using VolvoCars.EnergyApi.Interfaces;
using VolvoCars.EnergyApi.Services;

namespace VolvoCars.EnergyApi.IntegrationTest.Services
{
    public class EnergyApiClientTests
    {
        private IEnergyApiClient _apiClient;

        [OneTimeSetUp]
        public void Init()
        {
            var config = new ConfigurationBuilder().AddJsonFile("AppSettings.IntegrationTest.json").Build();
            _apiClient = new EnergyApiClient(config["vccApiKey"], "https://api.volvocars.com/energy/v1/", config["energyApiAccessToken"]);
        }

        [Test]
        public async Task GetRechargeStatusAsync()
        {
            var data = await _apiClient.GetRechargeStatusAsync(new Common.Domain.Vin("YV1XZEDVEN2703701"));

            data.Should().NotBeNull();
        }
    }
}
