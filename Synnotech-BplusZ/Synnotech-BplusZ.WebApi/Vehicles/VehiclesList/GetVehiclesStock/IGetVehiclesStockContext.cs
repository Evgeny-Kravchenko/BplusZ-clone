using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock
{
    public interface IGetVehiclesStockContext : IDisposable
    {
        public Task<IEnumerable<Vehicle>> GetStockVehicles(GetVehiclesStockDto getVehiclesDto);
    }
}
