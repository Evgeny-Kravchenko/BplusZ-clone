using Light.GuardClauses;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using Synnotech_BplusZ.WebApi.Extensions;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock
{
    public class GetVehiclesStockContext : GetVehiclesBaseContext<Vehicle, VehicleStockSearchIndexResult>, IGetVehiclesStockContext
    {
        public GetVehiclesStockContext(IAsyncDocumentSession session) : base(session)
        {

        }

        public async Task<VehiclePagedResult> GetStockVehicles(GetVehiclesStockDto dto)
        {
            IQueryable<VehicleStockSearchIndexResult> sessionQuery 
                = Session.Query<VehicleStockSearchIndexResult, VehiclesStock_Query>();

            if (!dto.AllowedStatuses.IsNullOrEmpty())
            {
                sessionQuery = sessionQuery.Where(v => v.Status.In(dto.AllowedStatuses));
            }
            if (!dto.AllowedVehicleClasses.IsNullOrEmpty())
            {
                sessionQuery = sessionQuery.Where(v => v.VehicleClass.In(dto.AllowedVehicleClasses));
            }

            var sortField = dto.SortField?.FirstCharToUpper() ?? nameof(VehicleStockSearchIndexResult.LicenseNumber);

            return await GetVehicles<VehiclePagedResult>(sessionQuery, dto, sortField);
        }

        protected override Expression<Func<VehicleStockSearchIndexResult, bool>> GetPredicate()
        {
            return v => v.DeleteDate == null
                        && v.Status != VehicleStatuses.Advance;
        }

        protected override Expression<Func<VehicleStockSearchIndexResult, object?>> GetFieldSelector(string? field)
        {
            return field switch
            {
                nameof(VehicleStockSearchIndexResult.LicenseNumber) => (VehicleStockSearchIndexResult v) => v.LicenseNumber,
                _ => (VehicleStockSearchIndexResult v) => v.Query,
            };
        }
    }
}
