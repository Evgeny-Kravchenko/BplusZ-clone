using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Users;
using System;

namespace Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel
{
    public class Finance
    {
        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public bool? VehiclePaid { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? ContactNumber { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public DateTime? StartOfContract { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public DateTime? EndOfContract { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? NetPriceChasis { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? NetPriceStructure { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? InterestRateInPercent { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? FinalInstalmentAmount { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public DateTime? ClosingRateDate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? LeasingRate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? FinancingRate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? HirePurchaseRate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? RentalRate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public DateTime? ResidualPurchaseValueAtTheBeginning { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public DateTime? ResidualPurchaseValueAtTheEnd { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? TypeOfFinancing { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? Institute { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? Contractor { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? ContractPeriod { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? CoCommitmentGuarantee { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? MultiKmBillingContract { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? MultiKmBillingFreeKmContract { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? AfaRate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? AfaInclInterst { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? AfaDuration { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? UsefulLife { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? RedemptionShares { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? ResidualPurchaseValue { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? MileageInKM { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? MultiKmAccountingRKV { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? MiltiKmAccountingFreeKmRKV { get; set; }
    }
}
