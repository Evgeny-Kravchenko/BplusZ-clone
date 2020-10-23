using System;

namespace Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel
{
    public class Finance
    {
        public bool? VehiclePaid { get; set; }
        public string? ContactNumber { get; set; }
        public DateTime? StartOfContract { get; set; }
        public DateTime? EndOfContract { get; set; }
        public decimal? NetPriceChasis { get; set; }
        public decimal? NetPriceStructure { get; set; }
        public decimal? InterestRateInPercent { get; set; }
        public decimal? FinalInstalmentAmount { get; set; }
        public DateTime? ClosingRateDate { get; set; }
        public decimal? LeasingRate { get; set; }
        public decimal? FinancingRate { get; set; }
        public decimal? HirePurchaseRate { get; set; }
        public decimal? RentalRate { get; set; }
        public DateTime? ResidualPurchaseValueAtTheBeginning { get; set; }
        public DateTime? ResidualPurchaseValueAtTheEnd { get; set; }
        public string? TypeOfFinancing { get; set; }
        public string? Institute { get; set; }
        public string? Contractor { get; set; }
        public string? ContractPeriod { get; set; }
        public string? CoCommitmentGuarantee { get; set; }
        public string? MultiKMBillingContract { get; set; }
        public string? MultiKMBillingFreeKBContract { get; set; }
        public string? AfaRate { get; set; }
        public string? AfaInclInterst { get; set; }
        public string? AfaDuration { get; set; }
        public string? UsefulLife { get; set; }
        public string? RedemptionShares { get; set; }
        public string? ResidualPurchaseValue { get; set; }
    }
}
