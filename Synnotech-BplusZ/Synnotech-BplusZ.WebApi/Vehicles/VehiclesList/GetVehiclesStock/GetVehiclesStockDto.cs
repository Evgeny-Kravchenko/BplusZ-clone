using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock

{
    public class GetVehiclesStockDto
    {
        public string? SearchTerm { get; set; }
        public string? SortField { get; set; }
        public List<string>? AllowedStatuses { get; set; }
        public List<string>? AllowedVehicleClasses { get; set; }
        public string? SearchField { get; set; }
        public bool IsAscendingSortOrder { get; set; } = true;
        [Range(0, int.MaxValue)]
        public int Skip { get; set; } = 0;
        [Range(0, 1000)]
        public int Take { get; set; } = 50;
    }
}
