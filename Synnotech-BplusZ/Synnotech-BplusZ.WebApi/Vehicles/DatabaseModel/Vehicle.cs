using System;

namespace Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel
{
    public class Vehicle
    {
        public string? Id { get; set; }
        public string? LicenceNumber { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? Status { get; set; }
        public string? State { get; set; }
        public string? Type { get; set; }
        public string? VehicleClass { get; set; }
        public DateTime? InitialRegistration { get; set; }
        public DateTime? Deregistration { get; set; }
        public decimal? MileageDate { get; set; }
        public DateTime? TotalDeliveryDate { get; set; }
        public string? Holder { get; set; }
        public bool? DoubleTaxed { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string? Info { get; set; }
        public string? Appointment { get; set; }
        public string? NumberOfInvestment { get; set; }
        public TechnicalComponents? TechnicalComponents { get; set; }
        public TechnicalContractData? TechnicalContractData { get; set; }
        public Finance? Finance { get; set; }
        public TransferData? TransferData { get; set; }
    }
}
