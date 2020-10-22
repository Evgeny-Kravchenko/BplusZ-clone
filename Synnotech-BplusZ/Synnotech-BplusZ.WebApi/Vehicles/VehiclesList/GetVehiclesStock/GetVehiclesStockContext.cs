using Light.GuardClauses;
using Raven.Client.Documents;
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

        public async Task<IEnumerable<Vehicle>> GetStockVehicles(GetVehiclesStockDto dto)
        {
            IQueryable<Vehicle> sessionQuery;

            if (!dto.SearchTerm.IsNullOrEmpty())
            {
                var searchFieldSelector = GetFieldSelector(dto.SearchField?.FirstCharToUpper());
                sessionQuery = Session.Query<VehicleStockSearchIndexResult, VehiclesStock_Query>()
                                        .Search(searchFieldSelector, $"*{dto.SearchTerm}*")
                                        .OfType<Vehicle>();
            }
            else
            {
                sessionQuery = Session.Query<Vehicle>();
            }

            if (!dto.AllowedStatuses.IsNullOrEmpty())
            {
                sessionQuery = sessionQuery.Where(v => dto.AllowedStatuses.Contains(v.Status ?? string.Empty));
            }
            if (!dto.AllowedVehicleClasses.IsNullOrEmpty())
            {
                sessionQuery = sessionQuery.Where(v => dto.AllowedVehicleClasses.Contains(v.VehicleClass ?? string.Empty));
            }

            var sortField = dto.SortField ?? nameof(Vehicle.LicenceNumber);
            var vehicles = await sessionQuery.Where(v => v.DeleteDate == null)
                                             .OrderBy(sortField, dto.IsAscendingSortOrder)
                                             .GetPage(dto.Skip, dto.Take)
                                             .ToListAsync();

            return vehicles;
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
