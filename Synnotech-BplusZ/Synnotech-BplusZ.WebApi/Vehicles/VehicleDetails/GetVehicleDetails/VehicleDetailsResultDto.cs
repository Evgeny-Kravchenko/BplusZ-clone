using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetails
{
    public class VehicleDetailsResultDto
    {
        public string? Id { get; set; }
        public string? LicenceNumber { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? ConstructionType { get; set; }
        public string? BranchOffice { get; set; }
        public string? Status { get; set; }
        public string? State { get; set; }
        public string? Type { get; set; }
        public TechnicalComponents? TechnicalComponents { get; set; }
        public TechnicalContractData? TechnicalContractData { get; set; }
        public Finance? Finance { get; set; }
        public TransferData? TransferData { get; set; }
    }
}
