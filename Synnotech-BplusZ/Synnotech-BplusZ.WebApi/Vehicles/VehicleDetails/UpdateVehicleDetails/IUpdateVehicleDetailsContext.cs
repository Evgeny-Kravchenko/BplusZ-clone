using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails
{
    public interface IUpdateVehicleDetailsContext : IDisposable
    {
        public Task<Vehicle> GetVehicleDetails(string vehicleId);
        public Task<Vehicle> UpdateVehicleDetails(Vehicle vehicle);
    }
}
