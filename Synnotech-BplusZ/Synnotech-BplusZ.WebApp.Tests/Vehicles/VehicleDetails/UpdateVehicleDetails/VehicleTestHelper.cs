using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails.Dtos;
using System;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehicleDetails.UpdateVehicleDetails
{
    public static class VehicleTestHelper
    {
        public static Vehicle GetTestVehicleDetails(string id)
        {
            return new Vehicle
            {
                Id = id,
                GeneralData = new GeneralData(),
                TechnicalComponents = new TechnicalComponents(),
                TechnicalContractData = new TechnicalContractData(),
                TransferData = new TransferData()
            };
        }

        public static UpdateVehicleDetailsDto GetTestVehicleDetailsDto(string id)
        {
            return new UpdateVehicleDetailsDto
            {
                Id = id,
                GeneralData = new GeneralDataDto
                {
                    Manufacturer = "Test Manufacturer",
                    Model = "Test Model",
                    Status = "Test Status",
                    ChassisNumber = "Test Chassis",
                    MileageDate = 49,
                    VehicleClass = "Test vehicle class"
                },
                TechnicalComponents = new TechnicalComponentsDto
                {
                    ManufacturerStructure = "Test Structure",
                    ConstructionType = "Test construction",
                    LoadingBoard = true,
                    StandClimate = true,
                },
                TechnicalContractData = new TechnicalContractDataDto
                {
                    MaintainanceAndRepair = "Test",
                    MileageInKmWPlusR = 124,
                    EndOfMaintainanceAndRepair = DateTime.Now
                },
                TransferData = new TransferDataDto
                {
                    BranchOffice = "Test branch office"
                }
            };
        }
    }
}
