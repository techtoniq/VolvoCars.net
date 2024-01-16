using VolvoCars.Common.Domain;

namespace VolvoCars.ConnectedVehicleApi.Domain
{
    public class VehicleDetails
    {
        public Vin Vin { get; set; } = default!;

        public string ModelYear { get; set; } = default!;
    }
}
