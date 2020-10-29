using Microsoft.Extensions.Configuration;
using Synnotech_BplusZ.WebApi.Mail;
using System;
using System.Linq;
using System.Threading.Tasks;
using Synnotech_BplusZ.WebApi.Infrastucture;
using Serilog;
using Light.GuardClauses;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleJobs
{
    public class VehicleService : IVehicleService
    {
        private readonly Func<IVehicleContext> _createVehicleContext;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;
        private readonly ILogger _logger;

        public VehicleService(Func<IVehicleContext> createVehicleContext,
            IConfiguration configuration,
            IMailService mailService)
        {
            _createVehicleContext = createVehicleContext;
            _configuration = configuration;
            _mailService = mailService;
            _logger = Logging.BaseLogger.ForContext<VehicleService>();
        }

        public async Task SendMailReportToGf()
        {
            try
            {
                var address = _configuration["GfReportAddress"];
                if (address.IsNullOrEmpty())
                    return;

                using var context = _createVehicleContext();
                var vehicles = await context.GetVehiclesForDailyReportToGf();
                var links = vehicles.Select(v => new Link
                {
                    Content = $"{v.GeneralData!.NumberOfInvestment} {v.GeneralData!.LicenseNumber} {v.TransferData!.BranchOffice}",
                    Href = $"{_configuration["vehicleDetailsPageUrl"]}/{v.Id}"
                });

                var email = await _mailService.CreateEmailWithLinksTable(new[] { address },
                    $"Bedarfsmeldungen {DateTime.Now.ToShortDateString()}",
                    "base-layout-template.html",
                    "vehicle-requests-to-gf-template.html",
                    "vehicle-request-row-template.html",
                    links);

                await _mailService.SendMailAsync(email);
            }
            catch(Exception exception)
            {
                _logger.Error(exception.Message, exception.StackTrace);
            }
        }
    }
}
