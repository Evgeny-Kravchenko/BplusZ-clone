using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehicleDetails.GetVehicleTechnicalContactDetails
{
    public static class VehicleTechnicalContractDetailsTestHelper
    {
        public static Vehicle GetTestVehicle()
        {
            return new Vehicle
            {
                TechnicalContractData = new TechnicalContractData()
            };
        }
    }
}
