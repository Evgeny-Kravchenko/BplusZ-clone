using SynDatabaseMigration.Core.TextVersions;
using SynDatabaseMigration.RavenDb;
using Synnotech_BplusZ.WebApi.Vehicles;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.DatabaseAccess.Migrations
{
    [MigrationVersion("0.1.0")]
    public sealed class AddSearchIndexForVehicles : AsyncRavenMigration
    {
        public override async Task ApplyAsync(DefaultAsyncRavenMigrationSession context)
        {
            var store = context.Session.Advanced.DocumentStore;
            await new Vehicles_Query().ExecuteAsync(store, store.Conventions);
        }
    }
}
