using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails
{
    public static class VehicleDetailsMapper
    {
        public static UpdateVehicleDetailsDto MapVehicleDetails(Vehicle vehicle)
        {
            return new UpdateVehicleDetailsDto
            {
                Id = vehicle.Id,
                GeneralData = vehicle.GeneralData,
                TechnicalComponents = vehicle.TechnicalComponents,
                TechnicalContractData = vehicle.TechnicalContractData,
                TransferData = vehicle.TransferData,
            };
        }

        public static Vehicle MapVehicleDetailsDto(UpdateVehicleDetailsDto vehicleDto)
        {
            return new Vehicle
            {
                Id = vehicleDto.Id,
                GeneralData = new GeneralData
                {
                    Manufacturer = vehicleDto.GeneralData?.Manufacturer,
                    Model = vehicleDto.GeneralData?.Model,
                    Status = vehicleDto.GeneralData?.Status,
                    ChassisNumber = vehicleDto.GeneralData?.ChassisNumber,
                    MileageDate = vehicleDto.GeneralData?.MileageDate,
                    VehicleClass = vehicleDto.GeneralData?.VehicleClass
                },
                TechnicalComponents = new TechnicalComponents
                {
                    ManufacturerStructure = vehicleDto.TechnicalComponents?.ManufacturerStructure,
                    ConstructionType = vehicleDto.TechnicalComponents?.ConstructionType,
                    LoadingBoard = vehicleDto.TechnicalComponents?.LoadingBoard,
                    StandClimate = vehicleDto.TechnicalComponents?.StandClimate
                },
                TechnicalContractData = new TechnicalContractData
                {
                    MaintainanceAndRepair = vehicleDto.TechnicalContractData?.MaintainanceAndRepair,
                    MileageInKmWPlusR = vehicleDto.TechnicalContractData?.MileageInKmWPlusR,
                    EndOfMaintainanceAndRepair = vehicleDto.TechnicalContractData?.EndOfMaintainanceAndRepair
                },
                TransferData = new TransferData
                {
                    BranchOffice = vehicleDto.TransferData?.BranchOffice,
                }
            };
        }
    }
}
