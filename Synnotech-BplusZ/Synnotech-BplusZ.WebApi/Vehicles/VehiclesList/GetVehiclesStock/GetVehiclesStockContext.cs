using Light.GuardClauses;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using SynDatabaseMigration.RavenDb;
using Synnotech_BplusZ.WebApi.Extensions;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock
{
    public class GetVehiclesStockContext : AsyncRavenSession, IGetVehiclesStockContext
    {
        public GetVehiclesStockContext(IAsyncDocumentSession session) : base(session)
        {
        }

        public async Task<(IEnumerable<Vehicle>, int)> GetStockVehicles(GetVehiclesStockDto dto)
        {
            IQueryable<VehicleStockSearchIndexResult> sessionQuery = Session.Query<VehicleStockSearchIndexResult, VehiclesStock_Query>();

            if (!dto.SearchTerm.IsNullOrEmpty())
            {
                var searchFieldSelector = GetFieldSelector(dto.SearchField);
                sessionQuery = sessionQuery.Search(searchFieldSelector, $"*{dto.SearchTerm}*");
            }

            if (!dto.AllowedStatuses.IsNullOrEmpty())
            {
                sessionQuery = sessionQuery.Where(v => v.Status.In(dto.AllowedStatuses));
            }
            if (!dto.AllowedVehicleClasses.IsNullOrEmpty())
            {
                sessionQuery = sessionQuery.Where(v => v.VehicleClass.In(dto.AllowedVehicleClasses));
            }

            var sortField = dto.SortField?.FirstCharToUpper() ?? nameof(VehicleStockSearchIndexResult.LicenceNumber);

            sessionQuery = sessionQuery.Where(v => v.DeleteDate == null)
                                            .OrderBy(sortField, dto.IsAscendingSortOrder);
            var count = await sessionQuery.CountAsync();
            var vehicles = await sessionQuery.GetPage(dto.Skip, dto.Take)
                                             .OfType<Vehicle>()
                                             .ToListAsync();

            return (vehicles, count);
        }

        private Expression<Func<VehicleStockSearchIndexResult, object?>> GetFieldSelector(string? field)
        {
            return field switch
            {
                nameof(VehicleStockSearchIndexResult.LicenceNumber) => (VehicleStockSearchIndexResult v) => v.LicenceNumber,
                _ => (VehicleStockSearchIndexResult v) => v.Query,
            };
        }
    }
}
