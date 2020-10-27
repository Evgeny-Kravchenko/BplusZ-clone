using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Users;
using System;

namespace Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel
{
    public class TechnicalContractData
    {
        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? MaintainanceAndRepair { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public DateTime? StartMaintainanceAndRepair { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public DateTime? EndOfMaintainanceAndRepair { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? MileageInKmWPlusR { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public bool? PoolingMaintainanceAndRepair { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public bool? MichelinContract { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public bool? TyreStorageForCompanyCars { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? MultiKMAccountingWPlusR { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? MultiKMAccountingFreeKMWPlusR { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? TelematicsProvider { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? TelematicsAmount { get; set; }
    }
}
