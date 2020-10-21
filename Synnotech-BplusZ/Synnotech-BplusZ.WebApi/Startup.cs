using Light.GuardClauses;
using LightInject;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Synnotech_BplusZ.WebApi.DatabaseAccess;
using Synnotech_BplusZ.WebApi.Infrastucture;
using Synnotech_BplusZ.WebApi.Tokens.CreateToken;
using Synnotech_BplusZ.WebApi.Vehicles.AuthorizeUser;
using Synnotech_BplusZ.WebApi.Vehicles.GetVehicles;
using System.Text;

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

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWTConfig:Secret"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthentication();

            ConfigureDIContainer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var allowedCorsOrigins = Configuration.GetSection("allowedCorsOrigins").Get<string[]>();
                if (!allowedCorsOrigins.IsNullOrEmpty())
                {
                    app.UseCors(builder => builder.WithOrigins(allowedCorsOrigins)
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod());
                }
            }

            if (!Configuration.GetValue<bool>("allowHttpConnections"))
                app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDIContainer()
        {
            var store = RavenDbSettings.FromConfiguration(Configuration)
               .InitializeConnection(_logger);

            _container.RegisterStoreAndSessionWithContainer(store)
               .RegisterMigrationEngine(store)
               .RunMigrations(_logger);

            _container.RegisterLogging();

            _container.RegisterScoped<IGetVehiclesContext, GetVehiclesContext>();
            _container.RegisterScoped<IAuthorizeUserContext, AuthorizeUserContext>();

            _container.RegisterScoped<ICreateTokenService, CreateTokenService>();
        }
    }
}
