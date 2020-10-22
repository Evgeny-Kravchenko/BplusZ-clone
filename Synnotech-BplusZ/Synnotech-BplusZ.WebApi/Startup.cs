using Light.GuardClauses;
using LightInject;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Synnotech_BplusZ.WebApi.DatabaseAccess;
using Synnotech_BplusZ.WebApi.Infrastucture;
using Synnotech_BplusZ.WebApi.Tokens.CreateToken;
using Synnotech_BplusZ.WebApi.Vehicles.AuthorizeUser;
using Synnotech_BplusZ.WebApi.Vehicles.GetVehicle;
using Synnotech_BplusZ.WebApi.Vehicles.GetVehicles;
using System.Text;

namespace Synnotech_BplusZ.WebApi
{
    public class Startup
    {
        private readonly ServiceContainer _container;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
            _container = DependencyInjectionContainer.Instance;
            _logger = Logger.BaseLogger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();

            if (_environment.IsDevelopment())
                services.AddCors();
            else
                services.AddSpaStaticFiles(options => options.RootPath = _configuration["clientPath"]);


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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWTConfig:Secret"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthentication();

            ConfigureSwagger(services);
            ConfigureDIContainer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var allowedCorsOrigins = _configuration.GetSection("allowedCorsOrigins").Get<string[]>();
                if (!allowedCorsOrigins.IsNullOrEmpty())
                {
                    app.UseCors(builder => builder.WithOrigins(allowedCorsOrigins)
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod());
                }
            }

            app.UseDefaultFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BplusZ API V1");
            });

            if (!_configuration.GetValue<bool>("allowHttpConnections"))
                app.UseHttpsRedirection();

            if (!_environment.IsDevelopment())
                app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (!_environment.IsDevelopment())
                app.UseSpa(spaBuilder => spaBuilder.Options.SourcePath = _configuration["clientPath"]);
        }

        private void ConfigureDIContainer()
        {
            var store = RavenDbSettings.FromConfiguration(_configuration)
               .InitializeConnection(_logger);

            _container.RegisterStoreAndSessionWithContainer(store)
               .RegisterMigrationEngine(store)
               .RunMigrations(_logger);

            _container.RegisterLogging();

            _container.RegisterScoped<IGetVehiclesContext, GetVehiclesContext>();
            _container.RegisterScoped<IAuthorizeUserContext, AuthorizeUserContext>();
            _container.RegisterScoped<IGetVehicleDetailsContext, GetVehicleDetailsContext>();

            _container.RegisterScoped<ICreateTokenService, CreateTokenService>();
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AS API", Version = "v1" });

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };
                c.AddSecurityRequirement(securityRequirement);
            });
        }

    }
}
