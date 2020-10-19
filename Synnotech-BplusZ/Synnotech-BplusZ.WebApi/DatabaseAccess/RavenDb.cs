using System;
using System.Text;
using LightInject;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using Serilog;
using SynDatabaseMigration.Core;
using SynDatabaseMigration.RavenDb;

namespace Synnotech_BplusZ.WebApi.DatabaseAccess
{
    public static class RavenDb
    {
        public static IDocumentStore InitializeConnection(this RavenDbSettings settings, ILogger logger)
        {
            logger.Information($"Initializing connection to database \"{settings.DatabaseName}\" on RavenDB server \"{settings.ServerUrl}\"...");
            return new DocumentStore
            {
                Urls = new[] { settings.ServerUrl },
                Database = settings.DatabaseName,
                Conventions = RavenDbConventions.CreateDefaultConventions()
            }
               .Initialize();
        }
        public static ServiceContainer RegisterStoreAndSession(this ServiceContainer container, IDocumentStore store)
        {
            container.RegisterInstance(store)
                     .Register(f => f.GetInstance<IDocumentStore>().OpenAsyncSession());
            return container;
        }
        public static ServiceContainer RegisterStoreAndSessionWithContainer(this ServiceContainer container, IDocumentStore store) => container.RegisterStoreAndSession(store);
        public static ServiceContainer RegisterMigrationEngine(this ServiceContainer container, IDocumentStore store)
        {
            container.Register(f => new DefaultAsyncRavenMigrationSession(f.GetInstance<IAsyncDocumentSession>()))
                     .Register(f => new AsyncRavenMigrationEngine(new AsyncSessionFactory(store)));

            return container;
        }
        public static void RunMigrations(this ServiceContainer container, ILogger logger)
        {
            logger.Information("Applying database migrations if necessary...");
            var engine = container.GetInstance<AsyncRavenMigrationEngine>();
            var summary = engine.MigrateAsync(typeof(RavenDb).Assembly, DateTime.Now).Result;
            if (!summary.TryGetAppliedMigrations(out var appliedMigrations))
                return;
            var stringBuilder = new StringBuilder().AppendLine("The following migrations were applied:");
            foreach (var appliedMigration in appliedMigrations)
            {
                stringBuilder.AppendLine($"{appliedMigration.Version} {appliedMigration.Name}");
            }
            logger.Information(stringBuilder.ToString());
        }
    }
}
