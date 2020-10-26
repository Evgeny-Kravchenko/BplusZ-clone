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
                GeneralData = vehicle.GeneralData,
                Finance = vehicle.Finance,
                TechnicalComponents = vehicle.TechnicalComponents,
                TechnicalContractData = vehicle.TechnicalContractData,
                TransferData = vehicle.TransferData
            };
        }
    }
}
