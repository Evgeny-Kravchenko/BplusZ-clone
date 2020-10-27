using Synnotech_BplusZ.WebApi.Vehicles;
using System;

namespace Synnotech_BplusZ.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RequiredPermissionsAttribute : Attribute
    {
        public string[]? Roles { get; set; }
        public ActionType? ActionType { get; set; }

        public RequiredPermissionsAttribute(ActionType actionType, params string[] roles)
        {
            Roles = roles;
            ActionType = actionType;
        }

        public RequiredPermissionsAttribute()
        {
        }
    }
}
