using System;

namespace Synnotech_BplusZ.WebApi.CronJobScheduler
{
    public class ScheduleConfig<TEntity> : IScheduleConfig<TEntity>
    {
        public string? CronExpression { get; set; }
        public TimeZoneInfo? TimeZoneInfo { get; set; }
    }
}
