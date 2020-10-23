using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleTechnicalContractDetails
{
    public class VehicleTechnicalContractDetailsResultDto : TechnicalContractData
    {
        public string? VehicleId { get; set; }
    }
}
