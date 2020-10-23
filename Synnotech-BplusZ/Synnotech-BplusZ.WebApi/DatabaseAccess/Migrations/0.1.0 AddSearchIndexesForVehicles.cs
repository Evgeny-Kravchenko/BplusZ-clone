using SynDatabaseMigration.Core.TextVersions;
using SynDatabaseMigration.RavenDb;
using Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance;
using Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.DatabaseAccess.Migrations
{
    [MigrationVersion("0.1.0")]
    public sealed class AddSearchIndexesForVehicles : AsyncRavenMigration
    {
        public override async Task ApplyAsync(DefaultAsyncRavenMigrationSession context)
        {
            var store = context.Session.Advanced.DocumentStore;
            await new VehiclesStock_Query().ExecuteAsync(store, store.Conventions);
            await new VehiclesAdvance_Query().ExecuteAsync(store, store.Conventions);
        }
    }
}
