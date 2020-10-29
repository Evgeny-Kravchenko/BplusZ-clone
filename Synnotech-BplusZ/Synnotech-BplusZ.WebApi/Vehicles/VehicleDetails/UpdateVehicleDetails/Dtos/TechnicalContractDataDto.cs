using System;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails.Dtos
{
    public class TechnicalContractDataDto
    {
        public string? MaintainanceAndRepair { get; set; }
        public decimal? MileageInKmWPlusR { get; set; }
        public DateTime? EndOfMaintainanceAndRepair { get; set; }
    }
}
