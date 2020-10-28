using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails.Dtos;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails
{
    public class UpdateVehicleDetailsDto
    {
        public string? Id { get; set; }
        public GeneralDataDto? GeneralData { get; set; }
        public TechnicalComponentsDto? TechnicalComponents { get; set; }
        public TechnicalContractDataDto? TechnicalContractData { get; set; }
        public TransferDataDto? TransferData { get; set; }
    }
}
