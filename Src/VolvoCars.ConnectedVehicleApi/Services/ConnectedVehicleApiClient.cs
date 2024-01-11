using VolvoCars.ConnectedVehicleApi.Interfaces;

namespace VolvoCars.ConnectedVehicleApi.Services
{
    public class ConnectedVehicleApiClient : IConnectedVehicleApiClient
    {
        public ConnectedVehicleApiClient(string vccApiKey, string accessToken)
        {

        }

        public ICollection<string> GetAllVehicles()
        {
            throw new NotImplementedException();
        }
    }
}
