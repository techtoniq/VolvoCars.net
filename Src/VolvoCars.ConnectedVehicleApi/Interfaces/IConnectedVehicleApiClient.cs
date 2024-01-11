namespace VolvoCars.ConnectedVehicleApi.Interfaces
{
    public interface IConnectedVehicleApiClient
    {
        ICollection<string> GetAllVehicles();
    }
}
