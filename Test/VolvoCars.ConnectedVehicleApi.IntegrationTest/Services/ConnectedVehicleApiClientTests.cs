using FluentAssertions;
using Microsoft.Extensions.Configuration;
using VolvoCars.ConnectedVehicleApi.Interfaces;
using VolvoCars.ConnectedVehicleApi.Services;

namespace VolvoCars.ConnectedVehicleApi.IntegrationTest.Services
{
    public class ConnectedVehicleApiClientTests
    {
        private IConnectedVehicleApiClient _apiClient;

        [OneTimeSetUp]
        public void Init()
        {
            var config = new ConfigurationBuilder().AddJsonFile("AppSettings.IntegrationTest.json").Build();
            _apiClient = new ConnectedVehicleApiClient(config["vccApiKey"], "https://api.volvocars.com/connected-vehicle/v2/", config["connectedApiAccessToken"]);
        }

        [Test]
        public async Task GetAllVehiclesAsync()
        {           
            var data = await _apiClient.GetAllVehiclesAsync();

            data.Should().NotBeNull();
            data.Should().NotBeEmpty();
        }

        [Test]
        public async Task GetVehicleDetailsAsync()
        {
            var data = await _apiClient.GetVehicleDetailsAsync(new Common.Domain.Vin("YV1XZEDVEN2703701"));

            data.Should().NotBeNull();
        }
    }
}
