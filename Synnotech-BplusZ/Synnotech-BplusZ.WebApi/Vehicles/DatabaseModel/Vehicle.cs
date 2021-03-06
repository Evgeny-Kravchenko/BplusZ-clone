using System;

namespace Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel
{
    public class Vehicle
    {
        public string? Id { get; set; }
        public GeneralData? GeneralData { get; set; }
        public TechnicalComponents? TechnicalComponents { get; set; }
        public TechnicalContractData? TechnicalContractData { get; set; }
        public Finance? Finance { get; set; }
        public TransferData? TransferData { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
