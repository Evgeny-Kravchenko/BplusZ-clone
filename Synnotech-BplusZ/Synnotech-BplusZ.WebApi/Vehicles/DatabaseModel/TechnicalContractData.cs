using System;

namespace Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel
{
    public class TechnicalContractData
    {
        public string? MaintainanceAndRepair { get; set; }
        public DateTime? StartMaintainanceAndRepair { get; set; }
        public DateTime? EndOfMaintainanceAndRepair { get; set; }
        public decimal? MileageInKmWPlusR { get; set; }
        public bool? PoolingMaintainanceAndRepair { get; set; }
        public bool? MichelinContract { get; set; }
        public bool? TyreStorageForCompanyCars { get; set; }
        public string? MultiKMAccountingWPlusR { get; set; }
        public string? MultiKMAccountingFreeKMWPlusR { get; set; }
        public string? TelematicsProvider { get; set; }
        public decimal? TelematicsAmount { get; set; }
    }
}
