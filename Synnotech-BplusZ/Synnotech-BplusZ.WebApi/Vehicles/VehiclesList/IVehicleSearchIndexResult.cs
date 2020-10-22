using System.Collections.Generic;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList
{
    public interface IVehicleSearchIndexResult
    {
        public string? LicenceNumber { get; set; }
        public List<string>? Query { get; set; }
    }
}
