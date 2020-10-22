using Raven.Client.Documents.Session;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance
{
    public class GetVehiclesAdvanceContext : BaseGetVehicleContext, IGetVehiclesAdvanceContext
    {
        public GetVehiclesAdvanceContext(IAsyncDocumentSession session) : base(session)
        {
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAdvance(GetVehiclesDto dto)
        {
            return await GetVehicles<VehicleAdvanceSearchIndexResult, VehiclesAdvance_Query>(dto);
        }
    }
}
