using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Users;

namespace Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel
{
    public class TechnicalComponents
    {
        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? ConstructionType { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public bool? TrailerCoupling { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public bool? LoadingBoard { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public bool? RearViewCamera { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public bool? FifthWheelHeightAdjustable { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public bool? StandClimate { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public bool? Dashcam { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public bool? Retarder { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public string? Colour { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public DimensionsModel? InternalDimensions { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public bool? SteerableTrailingAxle { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? ManufacturerStructure { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? TypeOfTrailerCoulping { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? CoolingUnitManufacturer { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? CoolingUnitType { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? PollutantClass { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? ClientLabelling { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public int? NumberOfParkingSpaces { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public ParkingHeight? ParkingHeight { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public int? RideHeight { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public WBLength? WBLength { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public TyreSize? TyreSize { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public decimal? AdmissibleTotalWeight { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public decimal? Payload { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF)]
        public decimal? EmptyWeight { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public int? NumberOfAxes { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public string? FuelTypeEnergySource { get; set; }

        [RequiredPermissions(ActionType.All, UserRoles.FP, UserRoles.GF, UserRoles.NLL)]
        public decimal? FuelCapacity { get; set; }
    }
}
