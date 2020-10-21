using Microsoft.AspNetCore.Identity;
using Synnotech_BplusZ.WebApi.Users.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Users
{
    public static class PasswordHashHelper
    {
        public static string HashPassword(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(user, password);
        }

        public static bool VerifyHash(User user, string hashedPassword, string confirmPassword)
        {
            var passwordHasher = new PasswordHasher<User>();
            bool verified = false;
            var result = passwordHasher.VerifyHashedPassword(user, hashedPassword, confirmPassword);
            if (result == PasswordVerificationResult.Success) verified = true;
            else if (result == PasswordVerificationResult.SuccessRehashNeeded) verified = true;
            else if (result == PasswordVerificationResult.Failed) verified = false;

            return verified;
        }
    }
}
