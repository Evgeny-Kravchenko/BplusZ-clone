using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System.Collections.Generic;
using System.Linq;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock
{
    public static class VehiclesStockMapper
    {
        public static VehicleStockResultDto MapVehicle(Vehicle vehicle)
        {
            return new VehicleStockResultDto
            { 
                Id = vehicle.Id,
                BranchOffice = vehicle.TransferData?.BranchOffice,
                LicenceNumber = vehicle.LicenceNumber,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Status = vehicle.Status,
                Type = vehicle.Type,
                ConstructionType = vehicle.TechnicalComponents?.ConstructionType,
                Appointment = vehicle.Appointment,
                Info = vehicle.Info,
                VehicleClass = vehicle.VehicleClass,
            };
        }

        public static IEnumerable<VehicleStockResultDto> MapVehicles(IEnumerable<Vehicle> vehicles)
        {
            return vehicles.Select(v => MapVehicle(v));
        }
    }
}
