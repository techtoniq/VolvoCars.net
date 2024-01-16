using FluentAssertions;
using Microsoft.Extensions.Configuration;
using VolvoCars.LocationApi.Interfaces;
using VolvoCars.LocationApi.Services;

namespace VolvoCars.LocationApi.IntegrationTest.Services
{
    public class LocationApiClientTests
    {
        private ILocationApiClient _apiClient;

        [OneTimeSetUp]
        public void Init()
        {
            var config = new ConfigurationBuilder().AddJsonFile("AppSettings.IntegrationTest.json").Build();
            _apiClient = new LocationApiClient(config["vccApiKey"], "https://api.volvocars.com/location/v1/", config["locationApiAccessToken"]);
        }

        [Test]
        public async Task GetVehicleLocationAsync()
        {
            var data = await _apiClient.GetVehicleLocationDetailsAsync(new Common.Domain.Vin("YV1XZEDVEN2703701"));

            data.Should().NotBeNull();
        }
    }
}
