using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.GetVehicle
{
    public interface IGetVehicleDetailsContext : IDisposable
    {
        public Task<Vehicle> GetVehicleDetails(string vehicleId);
    }
}
