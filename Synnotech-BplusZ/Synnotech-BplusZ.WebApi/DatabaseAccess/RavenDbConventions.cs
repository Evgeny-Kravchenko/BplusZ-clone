using Raven.Client.Documents.Conventions;

namespace Synnotech_BplusZ.WebApi.DatabaseAccess
{
    public static class RavenDbConventions
    {
        public static DocumentConventions CreateDefaultConventions() => new DocumentConventions().SetDefaultConventions();

        public static DocumentConventions SetDefaultConventions(this DocumentConventions conventions)
        {
            conventions.IdentityPartsSeparator = '-';
            return conventions;
        }
    }
}
