using System.Text.Json.Nodes;

namespace VolvoCars.ConnectedVehicleApi.Interfaces
{
    public interface IConnectedVehicleApiClient
    {
        Task<JsonObject?> GetAllVehiclesAsync();
    }
}
