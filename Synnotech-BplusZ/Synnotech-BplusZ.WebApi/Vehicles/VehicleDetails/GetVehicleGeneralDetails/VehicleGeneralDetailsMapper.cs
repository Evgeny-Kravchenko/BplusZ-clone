using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleGeneralDetails
{
    public static class VehicleGeneralDetailsMapper
    {
        public static VehicleDetailsGeneralResultDto MapVehicleDetails(Vehicle vehicle)
        {
            return new VehicleDetailsGeneralResultDto
            {
                VehicleId = vehicle.Id,
                LicenceNumber = vehicle.GeneralData?.LicenceNumber,
                Manufacturer = vehicle.GeneralData?.Manufacturer,
                Model = vehicle.GeneralData?.Model,
                Status = vehicle.GeneralData?.Status,
                ChangeOfLicencePlate = vehicle.GeneralData?.ChangeOfLicencePlate,
                ChassisNumber = vehicle.GeneralData?.ChassisNumber,
                Deregistration = vehicle.GeneralData?.Deregistration,
                DoubleTaxed = vehicle.GeneralData?.DoubleTaxed,
                Holder = vehicle.GeneralData?.Holder,
                InitialRegistration = vehicle.GeneralData?.InitialRegistration,
                MileageDate = vehicle.GeneralData?.MileageDate,
                NumberOfInvestment = vehicle.GeneralData?.NumberOfInvestment,
                Picture = vehicle.GeneralData?.Picture,
                SupplierContactDetails = vehicle.GeneralData?.SupplierContactDetails,
                TotalDeliveryDate = vehicle.GeneralData?.TotalDeliveryDate,
                VehicleCategory = vehicle.GeneralData?.VehicleCategory,
                VehicleClass = vehicle.GeneralData?.VehicleClass,
            };
        }
    }
}
