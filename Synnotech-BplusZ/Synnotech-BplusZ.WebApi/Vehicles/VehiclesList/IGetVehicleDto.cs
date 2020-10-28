using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList
{
    public interface IGetVehicleDto
    {
        string? SearchTerm { get; set; }
        string? SortField { get; set; }
        string? SearchField { get; set; }
        bool IsAscendingSortOrder { get; set; }
        int Skip { get; set; } 
        int Take { get; set; }
    }
}
