using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails
{
    public class UpdateVehicleDetailsDto
    {
        public string? Id { get; set; }
        public GeneralData? GeneralData { get; set; }
        public TechnicalComponents? TechnicalComponents { get; set; }
        public TechnicalContractData? TechnicalContractData { get; set; }
        public TransferData? TransferData { get; set; }
    }
}
