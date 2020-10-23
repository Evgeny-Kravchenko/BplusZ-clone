using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleTechnicalComponents
{
    public static class VehicleTechnicalComponentsMapper
    {
        public static VehicleTechnicalComponentsResultDto MapVehicleDetails(Vehicle vehicle)
        {
            return new VehicleTechnicalComponentsResultDto
            {
                VehicleId = vehicle.Id,
                AdmissibleTotalWeight = vehicle.TechnicalComponents!.AdmissibleTotalWeight,
                TyreSize = vehicle.TechnicalComponents!.TyreSize,
                WBLength = vehicle.TechnicalComponents!.WBLength,
                ParkingHeight = vehicle.TechnicalComponents!.ParkingHeight,
                ClientLabelling = vehicle.TechnicalComponents!.ClientLabelling,
                Colour = vehicle.TechnicalComponents!.Colour,
                ConstructionType = vehicle.TechnicalComponents!.ConstructionType,
                CoolingUnitManufacturer = vehicle.TechnicalComponents!.CoolingUnitManufacturer,
                Dashcam = vehicle.TechnicalComponents!.Dashcam,
                EmptyWeight = vehicle.TechnicalComponents!.EmptyWeight,
                FifthWheelHeightAdjustable = vehicle.TechnicalComponents!.FifthWheelHeightAdjustable,
                FuelCapacity = vehicle.TechnicalComponents!.FuelCapacity,
                FuelTypeEnergySource = vehicle.TechnicalComponents!.FuelTypeEnergySource,
                InternalDimensions = vehicle.TechnicalComponents!.InternalDimensions,
                LoadingBoard = vehicle.TechnicalComponents!.LoadingBoard,
                ManufacturerStructure = vehicle.TechnicalComponents!.ManufacturerStructure,
                NumberOfAxes = vehicle.TechnicalComponents!.NumberOfAxes,
                NumberOfParkingSpaces = vehicle.TechnicalComponents!.NumberOfParkingSpaces,
                Payload = vehicle.TechnicalComponents!.Payload,
                PollutantClass = vehicle.TechnicalComponents!.PollutantClass,
                RearViewCamera = vehicle.TechnicalComponents!.RearViewCamera,
                Retarder = vehicle.TechnicalComponents!.Retarder,
                RideHeight = vehicle.TechnicalComponents!.RideHeight,
                StandClimate = vehicle.TechnicalComponents!.StandClimate,
                SteerableTrailingAxle = vehicle.TechnicalComponents!.SteerableTrailingAxle,
                TrailerCoupling = vehicle.TechnicalComponents!.TrailerCoupling,
                TypeOfTrailerCoulping = vehicle.TechnicalComponents!.TypeOfTrailerCoulping
            };
        }
    }
}
