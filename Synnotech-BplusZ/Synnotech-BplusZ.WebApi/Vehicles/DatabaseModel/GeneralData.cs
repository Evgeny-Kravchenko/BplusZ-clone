using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Users;
using System;

namespace Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel
{
    public class GeneralData
    {
        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? LicenseNumber { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? Manufacturer { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? Model { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? Status { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? State { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? Type { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? VehicleClass { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public DateTime? InitialRegistration { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public DateTime? Deregistration { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public int? MileageDate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public DateTime? TotalDeliveryDate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? Holder { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public bool? DoubleTaxed { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? Info { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? Appointment { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? NumberOfInvestment { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? ChangeOfLicencePlate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? ChassisNumber { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? VehicleCategory { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? SupplierContactDetails { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? Picture { get; set; }
    }
}
