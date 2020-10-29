using System;

namespace Synnotech_BplusZ.WebApi.CronJobScheduler
{
    public interface IScheduleConfig<TEntity>
    {
        string? CronExpression { get; set; }
        TimeZoneInfo? TimeZoneInfo { get; set; }
    }
}
