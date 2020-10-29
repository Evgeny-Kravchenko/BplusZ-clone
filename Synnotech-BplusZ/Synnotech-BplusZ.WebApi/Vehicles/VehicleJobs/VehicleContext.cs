using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using SynDatabaseMigration.RavenDb;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleJobs
{
    public class VehicleContext : AsyncRavenSession, IVehicleContext
    {
        public VehicleContext(IAsyncDocumentSession session) : base(session)
        {
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesForDailyReportToGf()
        {
            var neededDate = DateTime.Now.AddDays(-1);
            return await Session.Query<Vehicle>().Where(v => v.GeneralData.Status == VehicleStatuses.Advance
                                                             && v.GeneralData!.InitialRegistration > neededDate).ToListAsync();
        }
    }
}
