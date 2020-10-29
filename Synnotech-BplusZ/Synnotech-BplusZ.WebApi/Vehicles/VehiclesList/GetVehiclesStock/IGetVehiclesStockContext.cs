using System;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock
{
    public interface IGetVehiclesStockContext : IDisposable
    {
        public Task<VehiclePagedResult> GetStockVehicles(GetVehiclesStockDto getVehiclesDto);
    }
}
