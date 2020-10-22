using Raven.Client.Documents.Session;
using SynDatabaseMigration.RavenDb;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.GetVehicle
{
    public class GetVehicleDetailsContext : AsyncRavenSession, IGetVehicleDetailsContext
    {
        public GetVehicleDetailsContext(IAsyncDocumentSession session) : base(session)
        {
        }

        public async Task<Vehicle> GetVehicleDetails(string vehicleId)
        {
            return await Session.LoadAsync<Vehicle>(vehicleId);
        }
    }
}
