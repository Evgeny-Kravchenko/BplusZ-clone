using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Users;
using System;

namespace Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel
{
    public class TransferData
    {
        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? BranchOffice { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? Client { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public DateTime? TakeoverDate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public DateTime? TransferPeriod { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public bool? RegistrationCreditScania { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public bool? SurrenderAgreement { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public DateTime? StartOfRental { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public DateTime? EndOfLease { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public bool? TakeoverRecord { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public DateTime? ReturnDate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public bool? ReturnProtocol { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? Unit { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? CostCentre { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? OtherCosts { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? Tax { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? AmountInsured { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? Landlord { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? MileageInKM { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? MileageDay { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? MileageMonth { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? MileageYear { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? TransferCost { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? RentalRate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? SubtotalOfTransferCosts { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public decimal? SurrenderRate { get; set; }
    }
}
