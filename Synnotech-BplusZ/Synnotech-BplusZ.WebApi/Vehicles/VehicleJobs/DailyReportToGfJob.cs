using System;
using System.Threading;
using System.Threading.Tasks;
using Serilog;
using Synnotech_BplusZ.WebApi.CronJobScheduler;
using Synnotech_BplusZ.WebApi.Infrastucture;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleJobs
{
    public class DailyReportToGfJob : CronJobService
    {
        private readonly ILogger _logger;
        private readonly IVehicleService _vehicleService;

        public DailyReportToGfJob(IScheduleConfig<DailyReportToGfJob> config,
            IVehicleService vehicleService)
            : base(config.CronExpression!, config.TimeZoneInfo!)
        {
            _logger = Logging.BaseLogger.ForContext<DailyReportToGfJob>();
            _vehicleService = vehicleService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Daily Report to GF Job starts.");
            return base.StartAsync(cancellationToken);
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            _logger.Information($"{DateTime.Now:hh:mm:ss} Daily Report to GF Job is working.");
            await _vehicleService.SendMailReportToGf();
            _logger.Information($"{DateTime.Now:hh:mm:ss} Daily Report to GF Job is end working.");
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Daily Report to GF Job is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
