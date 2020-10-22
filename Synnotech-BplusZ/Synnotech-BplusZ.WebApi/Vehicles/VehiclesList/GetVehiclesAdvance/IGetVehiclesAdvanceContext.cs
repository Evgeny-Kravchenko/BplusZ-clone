using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance
{
    public interface IGetVehiclesAdvanceContext : IDisposable
    {
        public Task<IEnumerable<Vehicle>> GetVehiclesAdvance(GetVehiclesAdvancedDto getVehiclesDto);
    }
}
