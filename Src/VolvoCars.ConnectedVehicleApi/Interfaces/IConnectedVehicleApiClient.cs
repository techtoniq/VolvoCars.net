using VolvoCars.Common.Domain;

namespace VolvoCars.ConnectedVehicleApi.Interfaces
{
    public interface IConnectedVehicleApiClient
    {
        Task<IEnumerable<Vin>> GetAllVehiclesAsync();
    }
}
