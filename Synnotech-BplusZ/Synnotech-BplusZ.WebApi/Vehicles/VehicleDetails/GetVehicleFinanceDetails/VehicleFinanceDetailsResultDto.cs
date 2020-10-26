using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleFinanceDetails
{
    public class VehicleFinanceDetailsResultDto : Finance
    {
        public string? VehicleId { get; set; }
    }
}
