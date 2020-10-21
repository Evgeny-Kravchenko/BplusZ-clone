using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using SynDatabaseMigration.RavenDb;
using Synnotech_BplusZ.WebApi.Users.DatabaseModel;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.AuthorizeUser
{
    public class AuthorizeUserContext : AsyncRavenSession, IAuthorizeUserContext
    {
        public AuthorizeUserContext(IAsyncDocumentSession session) : base(session)
        {
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await Session.Query<User>()
                                .SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
