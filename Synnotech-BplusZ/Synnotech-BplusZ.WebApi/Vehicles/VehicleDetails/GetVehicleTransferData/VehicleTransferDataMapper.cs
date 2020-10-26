using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleTransferData
{
    public static class VehicleTransferDataMapper
    {
        public static VehicleTransferDataResultDto MapVehicleDetails(Vehicle vehicle)
        {
            return new VehicleTransferDataResultDto
            {
                VehicleId = vehicle.Id,
                BranchOffice = vehicle.TransferData!.BranchOffice,
                Client = vehicle.TransferData!.Client,
                EndOfLease = vehicle.TransferData!.EndOfLease,
                RegistrationCreditScania = vehicle.TransferData!.RegistrationCreditScania,
                ReturnDate = vehicle.TransferData!.ReturnDate,
                ReturnProtocol = vehicle.TransferData!.ReturnProtocol,
                StartOfRental = vehicle.TransferData!.StartOfRental,
                SurrenderAgreement = vehicle.TransferData!.SurrenderAgreement,
                TakeoverDate = vehicle.TransferData!.TakeoverDate,
                TakeoverRecord = vehicle.TransferData!.TakeoverRecord,
                TransferPeriod = vehicle.TransferData!.TransferPeriod,
                AmountInsured = vehicle.TransferData!.AmountInsured,
                CostCentre = vehicle.TransferData!.CostCentre,
                Landlord = vehicle.TransferData!.Landlord,
                MileageDay = vehicle.TransferData!.MileageDay,
                MileageInKM = vehicle.TransferData!.MileageInKM,
                MileageMonth = vehicle.TransferData!.MileageMonth,
                MileageYear = vehicle.TransferData!.MileageYear,
                OtherCosts = vehicle.TransferData!.OtherCosts,
                RentalRate = vehicle.TransferData!.RentalRate,
                SubtotalOfTransferCosts = vehicle.TransferData!.SubtotalOfTransferCosts,
                Tax = vehicle.TransferData!.Tax,
                TransferCots = vehicle.TransferData!.TransferCots,
                Unit = vehicle.TransferData!.Unit
            };
        }
    }
}
