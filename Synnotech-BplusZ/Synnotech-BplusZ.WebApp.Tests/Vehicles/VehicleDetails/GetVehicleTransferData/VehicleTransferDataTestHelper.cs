using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApp.Tests.Vehicles.VehicleDetails.GetVehicleTransferData
{
    public static class VehicleTransferDataTestHelper
    {
        public static Vehicle GetTestVehicle()
        {
            return new Vehicle
            {
                TransferData = new TransferData()
            };
        }
    }
}
