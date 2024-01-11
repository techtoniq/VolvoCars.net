using System.Configuration;
using VolvoCars.ConnectedVehicleApi.Services;

namespace VolvoCars.ConnectedVehicleApi.IntegrationTest.Services
{
    public class ConnectedVehicleApiClientTests
    {
        [Test]
        public void Foo()
        {
            var x = ConfigurationManager.AppSettings["configCheck"];

            var sut = new ConnectedVehicleApiClient("tbc", "tbc");

            var result = sut.GetAllVehicles();
        }
    }
}
