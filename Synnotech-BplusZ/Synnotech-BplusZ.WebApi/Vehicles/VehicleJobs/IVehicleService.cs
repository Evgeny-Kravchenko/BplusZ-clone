using System.Threading.Tasks;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleJobs
{
    public interface IVehicleService
    {
        Task SendMailReportToGf();
    }
}
