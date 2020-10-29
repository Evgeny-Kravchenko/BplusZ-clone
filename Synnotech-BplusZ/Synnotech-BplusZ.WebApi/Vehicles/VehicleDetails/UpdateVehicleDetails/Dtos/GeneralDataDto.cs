namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails.Dtos
{
    public class GeneralDataDto
    {
        public  string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? Status { get; set; }
        public string? ChassisNumber { get; set; }
        public int? MileageDate { get; set; }
        public string? VehicleClass { get; set; }
    }
}
