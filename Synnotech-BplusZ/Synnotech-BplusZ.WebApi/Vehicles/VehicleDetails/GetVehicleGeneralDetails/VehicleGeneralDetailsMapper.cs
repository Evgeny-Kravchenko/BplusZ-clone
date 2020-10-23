using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetailsGeneral
{
    public static class VehicleGeneralDetailsMapper
    {
        public static VehicleDetailsGeneralResultDto MapVehicleDetails(Vehicle vehicle)
        {
            return new VehicleDetailsGeneralResultDto
            {
                Id = vehicle.Id,
                LicenceNumber = vehicle.LicenceNumber,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Status = vehicle.Status,
                ChangeOfLicencePlate = vehicle.ChangeOfLicencePlate,
                ChassisNumber = vehicle.ChassisNumber,
                Deregistration = vehicle.Deregistration,
                DoubleTaxed = vehicle.DoubleTaxed,
                Holder = vehicle.Holder,
                InitialRegistration = vehicle.InitialRegistration,
                MileageDate = vehicle.MileageDate,
                NumberOfInvestment = vehicle.NumberOfInvestment,
                Picture = vehicle.Picture,
                SupplierContactDetails = vehicle.SupplierContactDetails,
                TotalDeliveryDate = vehicle.TotalDeliveryDate,
                VehicleCategory = vehicle.VehicleCategory,
                VehicleClass = vehicle.VehicleClass
            };
        }
    }
}
