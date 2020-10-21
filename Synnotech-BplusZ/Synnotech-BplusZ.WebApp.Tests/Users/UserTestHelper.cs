using Light.GuardClauses;
using Synnotech_BplusZ.WebApi.Users;
using Synnotech_BplusZ.WebApi.Users.DatabaseModel;
using System;

namespace Synnotech_BplusZ.WebApp.Tests.Users
{
    public static class UserTestHelper
    {
        public static User GetTestUser(string id = null,
            string email = "testtest@mail.com",
            string password = null,
            string role = UserRoles.NNL,
            bool deleted = false)
        {
            var user = new User {
                Id = id ?? Guid.NewGuid().ToString(),
                Email = email,
                Role = role,
                DeleteDate = deleted ? DateTime.Now : (DateTime?)null,
            };

            if(!password.IsNullOrEmpty())
            {
                user.PasswordHash = PasswordHashHelper.HashPassword(user, password);
            }

            return user;
        }
    }
}
