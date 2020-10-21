using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.GetVehicles
{
    public interface IGetVehiclesContext : IDisposable
    {
        public Task<IEnumerable<Vehicle>> GetVehicles(GetVehiclesDto getVehiclesDto);
    }
}
