using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System.Collections.Generic;
using System.Linq;

namespace Synnotech_BplusZ.WebApi.Vehicles.GetVehicles
{
    public static class VehicleMapper
    {
        public static VehicleResultDto MapVehicle(Vehicle vehicle)
        {
            return new VehicleResultDto
            { 
                Id = vehicle.Id,
                BranchOffice = vehicle.TransferData?.BranchOffice,
                LicenceNumber = vehicle.LicenceNumber,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Status = vehicle.StatusData?.Status,
                Type = vehicle.StatusData?.Type,
                ConstructionType = vehicle.TechnicalComponents?.ConstructionType,
                State = vehicle.StatusData?.State,
            };
        }

        public static IEnumerable<VehicleResultDto> MapVehicles(IEnumerable<Vehicle> vehicles)
        {
            return vehicles.Select(v => MapVehicle(v));
        }
    }
}
