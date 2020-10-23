using System;
using System.Collections.Generic;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock
{
    public class VehicleStockSearchIndexResult
    {
        public string? LicenceNumber { get; set; }
        public string? VehicleClass { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? ConstructionType { get; set; }
        public string? BranchOffice { get; set; }
        public string? Status { get; set; }
        public string? Type { get; set; }
        public string? Info { get; set; }
        public string? Appointment { get; set; }
        public DateTime? DeleteDate { get; set; }
        public List<string>? Query { get; set; }
    }
}
