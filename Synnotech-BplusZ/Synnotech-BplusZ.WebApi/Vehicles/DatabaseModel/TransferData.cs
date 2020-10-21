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
    }
}
