using Light.GuardClauses;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using SynDatabaseMigration.RavenDb;
using Synnotech_BplusZ.WebApi.Extensions;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleIndex;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.GetVehicles
{
    public class GetVehiclesContext : AsyncRavenSession, IGetVehiclesContext
    {
        public GetVehiclesContext(IAsyncDocumentSession session) : base(session)
        {
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles(GetVehiclesDto dto)
        {
            IQueryable<Vehicle> sessionQuery;

            if (!dto.SearchTerm.IsNullOrEmpty())
            {
                sessionQuery = Session.Query<VehicleSearchIndexResult, Vehicles_Query>()
                                      .Search(v => v.Query, $"*{dto.SearchTerm}*")
                                      .OfType<Vehicle>();
            }
            else
            {
                sessionQuery = Session.Query<Vehicle>();
            }

            var sortField = dto.SortField ?? nameof(Vehicle.LicenceNumber);
            var vehicles = await sessionQuery.Where(v => v.DeleteDate == null)
                                          .OrderBy(sortField, dto.IsAscendingSortOrder)
                                          .GetPage(dto.Skip, dto.Take)
                                          .ToListAsync();

            return vehicles;
        }
    }
}
