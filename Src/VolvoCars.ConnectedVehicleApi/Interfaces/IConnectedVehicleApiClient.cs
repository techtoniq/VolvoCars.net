using VolvoCars.Common.Domain;
using VolvoCars.ConnectedVehicleApi.Domain;

namespace VolvoCars.ConnectedVehicleApi.Interfaces
{
    public interface IConnectedVehicleApiClient
    {
        Task<IEnumerable<Vin>> GetAllVehiclesAsync();

        Task<VehicleDetails> GetVehicleDetailsAsync(Vin vin);
    }
}
