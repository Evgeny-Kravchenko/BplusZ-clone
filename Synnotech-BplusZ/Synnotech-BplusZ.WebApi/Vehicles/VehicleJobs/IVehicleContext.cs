using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleJobs
{
    public interface IVehicleContext : IDisposable
    {
        Task<IEnumerable<Vehicle>> GetVehiclesForDailyReportToGf();
    }
}
