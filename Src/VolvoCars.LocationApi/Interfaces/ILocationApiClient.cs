using VolvoCars.Common.Domain;
using VolvoCars.LocationApi.Domain;

namespace VolvoCars.LocationApi.Interfaces
{
    public interface ILocationApiClient
    {
        Task<LocationDetails> GetVehicleLocationDetailsAsync(Vin vin);
    }
}
