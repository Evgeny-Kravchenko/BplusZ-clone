namespace Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel
{
    public class TechnicalComponents
    {
        public string? ConstructionType { get; set; }
        public bool? TrailerCoupling { get; set; }
        public bool? LoadingBoard { get; set; }
        public bool? RearViewCamera { get; set; }
        public bool? FifthWheelHeightAdjustable { get; set; }
        public bool? StandClimate { get; set; }
        public bool? Dashcam { get; set; }
        public bool? Retarder { get; set; }
        public string? Colour { get; set; }
        public DimensionsModel? InternalDimensions { get; set; }
        public bool? SteerableTrailingAxle { get; set; }
        public string? ManufacturerStructure { get; set; }
        public string? TypeOfTrailerCoulping { get; set; }
        public string? CoolingUnitManufacturer { get; set; }
        public string? PollutantClass { get; set; }
        public string? ClientLabelling { get; set; }
        public int? NumberOfParkingSpaces { get; set; }
        public ParkingHeight? ParkingHeight { get; set; }
        public int? RideHeight { get; set; }
        public WBLength? WBLength { get; set; }
        public TyreSize? TyreSize { get; set; }
        public decimal? AdmissibleTotalWeight { get; set; }
        public decimal? Payload { get; set; }
        public decimal? EmptyWeight { get; set; }
        public int? NumberOfAxes { get; set; }
        public string? FuelTypeEnergySource { get; set; }
        public decimal? FuelCapacity { get; set; }
    }
}
