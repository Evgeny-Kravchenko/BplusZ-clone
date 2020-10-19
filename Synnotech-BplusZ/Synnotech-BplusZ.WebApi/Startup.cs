using LightInject;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Synnotech_BplusZ.WebApi.DatabaseAccess;
using Synnotech_BplusZ.WebApi.Infrastucture;

namespace Synnotech_BplusZ.WebApi
{
    public class Startup
    {
        private readonly ServiceContainer _container;
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _container = DependencyInjectionContainer.Instance;
            _logger = Logger.BaseLogger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureDIContainer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDIContainer()
        {
            var store =  RavenDbSettings.FromConfiguration(Configuration)
               .InitializeConnection(_logger);

            _container.RegisterStoreAndSessionWithContainer(store)
               .RegisterMigrationEngine(store)
               .RunMigrations(_logger);

            _container.RegisterLogging();
        }
     }
}
