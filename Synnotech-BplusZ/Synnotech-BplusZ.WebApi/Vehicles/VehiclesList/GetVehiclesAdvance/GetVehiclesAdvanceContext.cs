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

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance
{
    public class GetVehiclesAdvanceContext : AsyncRavenSession, IGetVehiclesAdvanceContext
    {
        public GetVehiclesAdvanceContext(IAsyncDocumentSession session) : base(session)
        {
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAdvance(GetVehiclesAdvancedDto dto)
        {
            IQueryable<Vehicle> sessionQuery;

            if (!dto.SearchTerm.IsNullOrEmpty())
            {
                var searchFieldSelector = GetFieldSelector(dto.SearchField);
                sessionQuery = Session.Query<VehicleAdvanceSearchIndexResult, VehiclesAdvance_Query>()
                                        .Search(searchFieldSelector, $"*{dto.SearchTerm}*")
                                        .OfType<Vehicle>();
            }
            else
            {
                sessionQuery = Session.Query<Vehicle>();
            }

            if (!dto.AllowedStates.IsNullOrEmpty())
            {
                sessionQuery = sessionQuery.Where(v => dto.AllowedStates.Contains(v.State ?? string.Empty));
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

        private Expression<Func<VehicleAdvanceSearchIndexResult, object?>> GetFieldSelector(string? field)
        {
            return field switch
            {
                nameof(VehicleAdvanceSearchIndexResult.LicenceNumber) => (VehicleAdvanceSearchIndexResult v) => v.LicenceNumber,
                nameof(VehicleAdvanceSearchIndexResult.NumberOfInvestment) => (VehicleAdvanceSearchIndexResult v) => v.NumberOfInvestment,
                _ => (VehicleAdvanceSearchIndexResult v) => v.Query,
            };
        }
    }
}
