using System;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleDetailsGeneral
{
    public class VehicleDetailsGeneralResultDto
    {
        public string? Id { get; set; }
        public string? LicenceNumber { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? Status { get; set; }
        public string? VehicleClass { get; set; }
        public DateTime? InitialRegistration { get; set; }
        public DateTime? Deregistration { get; set; }
        public decimal? MileageDate { get; set; }
        public DateTime? TotalDeliveryDate { get; set; }
        public string? Holder { get; set; }
        public bool? DoubleTaxed { get; set; }
        public string? NumberOfInvestment { get; set; }
        public string? ChangeOfLicencePlate { get; set; }
        public string? ChassisNumber { get; set; }
        public string? VehicleCategory { get; set; }
        public string? SupplierContactDetails { get; set; }
        public string? Picture { get; set; }
    }
}
