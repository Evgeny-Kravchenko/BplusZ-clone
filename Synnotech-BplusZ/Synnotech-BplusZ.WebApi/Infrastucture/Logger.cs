using LightInject;
using Serilog;
using System.IO;

namespace Synnotech_BplusZ.WebApi.Infrastucture
{
    public static class Logger
    {
        public static readonly string LoggingDirectory = Path.Combine(Path.GetDirectoryName(typeof(Logger).Assembly.Location)!, "Logs");

        public static readonly ILogger BaseLogger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.RollingFile(Path.Combine(LoggingDirectory, "{Date}_BplusZ.log"))
            .WriteTo.Console()
            .CreateLogger();

        public static ServiceContainer RegisterLogging(this ServiceContainer container)
        {
            container.RegisterInstance(BaseLogger);

            return container;
        }
    }
}
