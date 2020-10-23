using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehicleDetails.GetVehicleTechnicalComponents
{
    public static class VehicleTechnicalComponentsTestHelper
    {
        public static Vehicle GetTestVehicle()
        {
            return new Vehicle
            {
                TechnicalComponents = new TechnicalComponents()
            };
        }
    }
}
