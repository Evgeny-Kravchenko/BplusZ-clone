using Raven.Client.Documents.Session;
using SynDatabaseMigration.RavenDb;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails
{
    public class UpdateVehicleDetailsContext : AsyncRavenSession, IUpdateVehicleDetailsContext
    {
        public UpdateVehicleDetailsContext(IAsyncDocumentSession session) : base(session)
        {

        }

        public async Task<Vehicle> GetVehicleDetails(string vehicleId)
        {
            return await Session.LoadAsync<Vehicle>(vehicleId);
        }

        public async Task<Vehicle> UpdateVehicleDetails(Vehicle vehicle)
        {
            await Session.StoreAsync(vehicle);
            await Session.SaveChangesAsync();

            return vehicle;
        }
    }
}
