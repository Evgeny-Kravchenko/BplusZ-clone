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

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance
{
    public class GetVehiclesAdvanceContext : AsyncRavenSession, IGetVehiclesAdvanceContext
    {
        public GetVehiclesAdvanceContext(IAsyncDocumentSession session) : base(session)
        {
        }

        public async Task<(IEnumerable<Vehicle>, int)> GetVehiclesAdvance(GetVehiclesAdvancedDto dto)
        {
            IQueryable<VehicleAdvanceSearchIndexResult> sessionQuery = Session.Query<VehicleAdvanceSearchIndexResult, VehiclesAdvance_Query>();

            if (!dto.SearchTerm.IsNullOrEmpty())
            {
                var searchFieldSelector = GetFieldSelector(dto.SearchField);
                sessionQuery = sessionQuery.Search(searchFieldSelector, $"*{dto.SearchTerm}*");
            } 

            if (!dto.AllowedStates.IsNullOrEmpty())
            {
                sessionQuery = sessionQuery.Where(v => v.State.In(dto.AllowedStates));
            }
            if (!dto.AllowedVehicleClasses.IsNullOrEmpty())
            {
                sessionQuery = sessionQuery.Where(v => v.VehicleClass.In(dto.AllowedVehicleClasses));
            }

            var sortField = dto.SortField?.FirstCharToUpper() ?? nameof(VehicleAdvanceSearchIndexResult.LicenceNumber);
            sessionQuery = sessionQuery.Where(v => v.DeleteDate == null)
                                             .OrderBy(sortField, dto.IsAscendingSortOrder);

            var count = await sessionQuery.CountAsync();
            var vehicles = await sessionQuery.Where(v => v.DeleteDate == null)
                                             .OrderBy(sortField, dto.IsAscendingSortOrder)
                                             .GetPage(dto.Skip, dto.Take)
                                             .OfType<Vehicle>()
                                             .ToListAsync();

            return (vehicles, count);
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
