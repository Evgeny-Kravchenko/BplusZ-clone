using System;

namespace Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel
{
    public class TransferData
    {
        public string? BranchOffice { get; set; }
        public string? Client { get; set; }
        public DateTime? TakeoverDate { get; set; }
        public DateTime? TransferPeriod { get; set; }
        public bool? RegistrationCreditScania { get; set; }
        public bool? SurrenderAgreement { get; set; }
        public DateTime? StartOfRental { get; set; }
        public DateTime? EndOfLease { get; set; }
        public bool? TakeoverRecord { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool? ReturnProtocol { get; set; }
        public string? Unit { get; set; }
        public string? CostCentre { get; set; }
        public decimal? OtherCosts { get; set; }
        public decimal? Tax { get; set; }
        public decimal? AmountInsured { get; set; }
        public string? Landlord { get; set; }
        public string? MileageInKM { get; set; }
        public string? MileageDay { get; set; }
        public string? MileageMonth { get; set; }
        public string? MileageYear { get; set; }
        public decimal? TransferCots { get; set; }
        public decimal? RentalRate { get; set; }
        public decimal? SubtotalOfTransferCosts { get; set; }
    }
}
