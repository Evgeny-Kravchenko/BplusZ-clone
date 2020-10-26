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
                LicenceNumber = vehicle.GeneralData?.LicenceNumber,
                Manufacturer = vehicle.GeneralData?.Manufacturer,
                Model = vehicle.GeneralData?.Model,
                Status = vehicle.GeneralData?.Status,
                Type = vehicle.GeneralData?.Type,
                ConstructionType = vehicle.TechnicalComponents?.ConstructionType,
                Appointment = vehicle.GeneralData?.Appointment,
                Info = vehicle.GeneralData?.Info,
                VehicleClass = vehicle.GeneralData?.VehicleClass,
            };
        }

        public static IEnumerable<VehicleStockResultDto> MapVehicles(IEnumerable<Vehicle> vehicles)
        {
            return vehicles.Select(v => MapVehicle(v));
        }
    }
}
