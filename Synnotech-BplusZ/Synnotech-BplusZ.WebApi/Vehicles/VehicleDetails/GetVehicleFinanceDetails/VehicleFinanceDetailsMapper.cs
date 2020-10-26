using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleFinanceDetails
{
    public static class VehicleFinanceDetailsMapper
    {
        public static VehicleFinanceDetailsResultDto MapVehicleDetails(Vehicle vehicle)
        {
            return new VehicleFinanceDetailsResultDto
            {
                VehicleId = vehicle.Id,
                ClosingRateDate = vehicle.Finance!.ClosingRateDate,
                ContactNumber = vehicle.Finance!.ContactNumber,
                EndOfContract = vehicle.Finance!.EndOfContract,
                FinalInstalmentAmount = vehicle.Finance!.FinalInstalmentAmount,
                FinancingRate = vehicle.Finance!.FinancingRate,
                HirePurchaseRate = vehicle.Finance!.HirePurchaseRate,
                InterestRateInPercent = vehicle.Finance!.InterestRateInPercent,
                LeasingRate = vehicle.Finance!.LeasingRate,
                NetPriceChasis = vehicle.Finance!.NetPriceChasis,
                NetPriceStructure = vehicle.Finance!.NetPriceStructure,
                RentalRate = vehicle.Finance!.RentalRate,
                ResidualPurchaseValueAtTheBeginning = vehicle.Finance!.ResidualPurchaseValueAtTheBeginning,
                ResidualPurchaseValueAtTheEnd = vehicle.Finance!.ResidualPurchaseValueAtTheEnd,
                StartOfContract = vehicle.Finance!.StartOfContract,
                VehiclePaid = vehicle.Finance!.VehiclePaid,
                AfaDuration = vehicle.Finance!.AfaDuration,
                AfaInclInterst = vehicle.Finance!.AfaInclInterst,
                AfaRate = vehicle.Finance!.AfaRate,
                CoCommitmentGuarantee = vehicle.Finance!.CoCommitmentGuarantee,
                Contractor = vehicle.Finance!.Contractor,
                ContractPeriod = vehicle.Finance!.ContractPeriod,
                Institute = vehicle.Finance!.Institute,
                MultiKMBillingContract = vehicle.Finance!.MultiKMBillingContract,
                MultiKMBillingFreeKBContract = vehicle.Finance!.MultiKMBillingFreeKBContract,
                RedemptionShares = vehicle.Finance!.RedemptionShares,
                ResidualPurchaseValue = vehicle.Finance!.ResidualPurchaseValue,
                TypeOfFinancing = vehicle.Finance!.TypeOfFinancing,
                UsefulLife = vehicle.Finance!.UsefulLife
            };
        }
    }
}
