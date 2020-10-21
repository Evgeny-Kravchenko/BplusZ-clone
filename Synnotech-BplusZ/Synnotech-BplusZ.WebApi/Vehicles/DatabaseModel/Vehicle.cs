using System;

namespace Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel
{
    public class Vehicle
    {
        public string? Id { get; set; }
        public string? LicenceNumber { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public bool? Advance { get; set; }
        public bool? OnTheRoad { get; set; }
        public bool? Recovery { get; set; }
        public bool? WithoutInsert { get; set; }
        public bool? Garage { get; set; }
        public string? VehicleClass { get; set; }
        public DateTime? InitialRegistration { get; set; }
        public DateTime? Deregistration { get; set; }
        public string? MileageDate { get; set; }
        public DateTime? TotalDeliveryDate { get; set; }
        public string? Holder { get; set; }
        public bool? DoubleTaxed { get; set; }
        public DateTime? DeleteDate { get; set; }
        public TechnicalComponents? TechnicalComponents { get; set; }
        public TechnicalContractData? TechnicalContractData { get; set; }
        public Finance? Finance { get; set; }
        public TransferData? TransferData { get; set; }
        public StatusData? StatusData { get; set; }
    }
}
