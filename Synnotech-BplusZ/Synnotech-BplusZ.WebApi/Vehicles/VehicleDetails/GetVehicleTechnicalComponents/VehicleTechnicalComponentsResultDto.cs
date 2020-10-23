using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleTechnicalComponentsDetails
{
    public class VehicleTechnicalComponentsResultDto : TechnicalComponents
    {
        public string? VehicleId { get; set; }
    }
}
