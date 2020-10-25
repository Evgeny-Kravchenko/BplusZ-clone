using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleTechnicalContractDetails
{
    public static class VehicleTechnicalContractsMapper
    {
        public static VehicleTechnicalContractDetailsResultDto MapVehicleDetails(Vehicle vehicle)
        {
            return new VehicleTechnicalContractDetailsResultDto
            {
                VehicleId = vehicle.Id,
                EndOfMaintainanceAndRepair = vehicle.TechnicalContractData!.EndOfMaintainanceAndRepair,
                MaintainanceAndRepair = vehicle.TechnicalContractData!.MaintainanceAndRepair,
                MichelinContract = vehicle.TechnicalContractData!.MichelinContract,
                MileageInKmWPlusR = vehicle.TechnicalContractData!.MileageInKmWPlusR,
                PoolingMaintainanceAndRepair = vehicle.TechnicalContractData!.PoolingMaintainanceAndRepair,
                StartMaintainanceAndRepair = vehicle.TechnicalContractData!.StartMaintainanceAndRepair,
                TyreStorageForCompanyCars = vehicle.TechnicalContractData!.TyreStorageForCompanyCars,
                MultiKMAccountingFreeKMWPlusR = vehicle.TechnicalContractData!.MultiKMAccountingFreeKMWPlusR,
                MultiKMAccountingWPlusR = vehicle.TechnicalContractData!.MultiKMAccountingWPlusR,
                TelematicsAmount = vehicle.TechnicalContractData!.TelematicsAmount,
                TelematicsProvider = vehicle.TechnicalContractData!.TelematicsProvider
            };
        }
    }
}