using Microsoft.Extensions.DependencyInjection;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleJobs;
using System;

namespace Synnotech_BplusZ.WebApi.CronJobScheduler
{
    public static class CronJobsModule
    {
        public static void RegisterCronJobs(this IServiceCollection services)
        {
            services.AddCronJob<DailyReportToGfJob>(c =>
            {
                c.TimeZoneInfo = TimeZoneInfo.Local;
                c.CronExpression = @"0 18 * * *";
            });
        }
    }
}
