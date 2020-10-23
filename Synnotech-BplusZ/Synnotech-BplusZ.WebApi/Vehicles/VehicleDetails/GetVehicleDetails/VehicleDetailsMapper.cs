using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetails
{
    public static class VehicleDetailsMapper
    {
        public static VehicleDetailsResultDto MapVehicleDetails(Vehicle vehicle)
        {
            return new VehicleDetailsResultDto
            {
                Id = vehicle.Id,
                BranchOffice = vehicle.TransferData?.BranchOffice,
                LicenceNumber = vehicle.LicenceNumber,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Status = vehicle.Status,
                Type = vehicle.Type,
                ConstructionType = vehicle.TechnicalComponents?.ConstructionType,
                State = vehicle.State,
                Finance = vehicle.Finance,
                TechnicalComponents = vehicle.TechnicalComponents,
                TechnicalContractData = vehicle.TechnicalContractData,
                TransferData = vehicle.TransferData
            };
        }
    }
}
