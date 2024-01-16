namespace VolvoCars.EnergyApi.Domain
{
    public class BatteryChargeLevel
    {
        public string Value {  get; set; } = default!;
        public string Unit { get; set; } = default!;
        public string Timestamp { get; set; } = default!;
    }
}
