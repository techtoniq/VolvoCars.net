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
            _apiClient = new ConnectedVehicleApiClient(config["apiKey"], config["accessToken"]);
        }

        [Test]
        public async Task ProveConnectivity()
        {           
            var result = await _apiClient.GetAllVehiclesAsync();

            result.Should().NotBeNull();
        }
    }
}
