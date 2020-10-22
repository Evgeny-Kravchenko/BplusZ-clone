using System;
using System.Collections.Generic;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance
{
    public class VehicleAdvanceSearchIndexResult
    {
        public string? LicenceNumber { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? ConstructionType { get; set; }
        public string? BranchOffice { get; set; }
        public string? VehicleClass { get; set; }
        public string? State { get; set; }
        public string? NumberOfInvestment { get; set; }
        public DateTime? DeleteDate { get; set; }
        public List<string>? Query { get; set; }
    }
}
