using System;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance
{
    public interface IGetVehiclesAdvanceContext : IDisposable
    {
        public Task<VehiclePagedResult> GetVehiclesAdvance(GetVehiclesAdvancedDto getVehiclesDto);
    }
}
