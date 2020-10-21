using Microsoft.Extensions.Configuration;

namespace Synnotech_BplusZ.WebApi.DatabaseAccess
{
    public class RavenDbSettings
    {
        public const string SectionName = "ravenDbSettings";

        public string ServerUrl { get; set; } = "http://localhost:10001";

        public string DatabaseName { get; set; } = "BplusZ";

        public static RavenDbSettings FromConfiguration(IConfiguration configuration) => configuration.GetSection(SectionName)
                                                                                                      .Get<RavenDbSettings>();
    }
}
