using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetails
{
    public interface IGetVehicleDetailsContext : IDisposable
    {
        public Task<Vehicle> GetVehicleDetails(string vehicleId);
    }
}
