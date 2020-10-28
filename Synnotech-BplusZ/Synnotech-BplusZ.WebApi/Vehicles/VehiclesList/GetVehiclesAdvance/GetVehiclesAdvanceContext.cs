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
    public class GetVehiclesAdvanceContext : GetVehiclesBaseContext<Vehicle, VehicleAdvanceSearchIndexResult>, IGetVehiclesAdvanceContext
    {
        public GetVehiclesAdvanceContext(IAsyncDocumentSession session) : base(session)
        {
        }

        public async Task<VehiclePagedResult> GetVehiclesAdvance(GetVehiclesAdvancedDto dto)
        {
            IQueryable<VehicleAdvanceSearchIndexResult> sessionQuery = Session.Query<VehicleAdvanceSearchIndexResult, VehiclesAdvance_Query>();

            if (!dto.AllowedStates.IsNullOrEmpty())
            {
                sessionQuery = sessionQuery.Where(v => v.State.In(dto.AllowedStates));
            }
            if (!dto.AllowedVehicleClasses.IsNullOrEmpty())
            {
                sessionQuery = sessionQuery.Where(v => v.VehicleClass.In(dto.AllowedVehicleClasses));
            }

            var sortField = dto.SortField?.FirstCharToUpper() ?? nameof(VehicleAdvanceSearchIndexResult.LicenseNumber);
            return await GetVehicles<VehiclePagedResult>(sessionQuery, dto, sortField);
        }

        protected override Expression<Func<VehicleAdvanceSearchIndexResult, object?>> GetFieldSelector(string? field)
        {
            return field switch
            {
                nameof(VehicleAdvanceSearchIndexResult.LicenseNumber) => (VehicleAdvanceSearchIndexResult v) => v.LicenseNumber,
                nameof(VehicleAdvanceSearchIndexResult.NumberOfInvestment) => (VehicleAdvanceSearchIndexResult v) => v.NumberOfInvestment,
                _ => (VehicleAdvanceSearchIndexResult v) => v.Query,
            };
    }

        protected override Expression<Func<VehicleAdvanceSearchIndexResult, bool>> GetPredicate()
        {
            return v => v.DeleteDate == null
                        && v.Status == VehicleStatuses.Advance;
        }
    }
}
