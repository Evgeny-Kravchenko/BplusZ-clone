using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingModels
{
    public class VehicleFinanceDetailsDto : Finance
    {
        public string? VehicleId { get; set; }
    }
}
