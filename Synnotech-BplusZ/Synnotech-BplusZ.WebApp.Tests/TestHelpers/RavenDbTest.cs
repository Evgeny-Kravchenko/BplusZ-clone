using Light.GuardClauses;
using Raven.Client.Documents;
using Raven.TestDriver;
using SynDatabaseMigration.RavenDb;
using Synnotech_BplusZ.WebApi.DatabaseAccess;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApp.Tests.TestHelpers
{
    public abstract class RavenDbTest : RavenTestDriver, IDisposable
    {
        protected readonly IDocumentStore _documentStore;

        static RavenDbTest()
        {
            var netCoreVersionForRavenDbTestServer = TestSettings.RavenDbNetCoreVersion;
            if (netCoreVersionForRavenDbTestServer.IsNullOrWhiteSpace() || !TestSettings.RunRavenDbIntegrationTests)
                return;

            ConfigureServer(new TestServerOptions
            {
                FrameworkVersion = netCoreVersionForRavenDbTestServer
            });
        }

        protected RavenDbTest()
        {
            _documentStore = GetDocumentStore();
        }

        protected override void PreInitialize(IDocumentStore documentStore) =>
            documentStore.Conventions.SetDefaultConventions();

        protected async Task ApplyMigrations()
        {
            var migrationAssembly = typeof(RavenDb).Assembly;
            var engine = new AsyncRavenMigrationEngine(new AsyncSessionFactory(_documentStore));
            await engine.MigrateAsync(migrationAssembly, DateTime.UtcNow);
        }

        public override void Dispose()
        {
            _documentStore.Dispose();
            base.Dispose();
        }
    }
}
