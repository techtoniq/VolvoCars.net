using VolvoCars.Common.Domain;
using VolvoCars.EnergyApi.Domain;

namespace VolvoCars.EnergyApi.Interfaces
{
    public interface IEnergyApiClient
    {
        Task<RechargeStatus> GetRechargeStatusAsync(Vin vin);
    }
}
