using System;

namespace Synnotech_BplusZ.WebApi.Users.DatabaseModel
{
    public class User
    {
        public string? Id { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
