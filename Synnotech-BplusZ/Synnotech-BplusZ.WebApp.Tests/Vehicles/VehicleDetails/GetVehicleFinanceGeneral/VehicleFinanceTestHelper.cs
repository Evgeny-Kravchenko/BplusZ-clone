using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehicleDetails.GetVehicleDetailsFinance
{
    public static class VehicleFinanceTestHelper
    {
        public static Vehicle GetTestVehicleFinanceDetails()
        {
            return new Vehicle
            {
                Finance = new Finance()
            };
        }
    }
}
