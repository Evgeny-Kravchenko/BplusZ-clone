using Raven.Client.Documents.Session;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock
{
    public class GetVehiclesStockContext : BaseGetVehicleContext, IGetVehiclesStockContext
    {
        public GetVehiclesStockContext(IAsyncDocumentSession session) : base(session)
        {
        }

        public async Task<IEnumerable<Vehicle>> GetStockVehicles(GetVehiclesDto dto)
        {
             return await GetVehicles<VehicleStockSearchIndexResult, VehiclesStock_Query>(dto);
        }
    }
}
