using Synnotech_BplusZ.WebApi.Users.DatabaseModel;
using System;
using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.AuthorizeUser
{
    public interface IAuthorizeUserContext : IDisposable
    {
        public Task<User> GetUserByEmail(string email);
    }
}
