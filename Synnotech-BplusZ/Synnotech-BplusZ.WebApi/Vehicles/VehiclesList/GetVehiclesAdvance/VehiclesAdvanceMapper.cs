using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System.Collections.Generic;
using System.Linq;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance
{
    public static class VehiclesAdvanceMapper
    {
        public static VehicleAdvanceResultDto MapVehicle(Vehicle vehicle)
        {
            return new VehicleAdvanceResultDto
            {
                Id = vehicle.Id,
                BranchOffice = vehicle.TransferData?.BranchOffice,
                LicenceNumber = vehicle.LicenceNumber,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                State = vehicle.State,
                ConstructionType = vehicle.TechnicalComponents?.ConstructionType,
                NumberOfInvestment = vehicle.NumberOfInvestment,
                VehicleClass = vehicle.VehicleClass,
            };
        }

        public static IEnumerable<VehicleAdvanceResultDto> MapVehicles(IEnumerable<Vehicle> vehicles)
        {
            return vehicles.Select(v => MapVehicle(v));
        }
    }
}
