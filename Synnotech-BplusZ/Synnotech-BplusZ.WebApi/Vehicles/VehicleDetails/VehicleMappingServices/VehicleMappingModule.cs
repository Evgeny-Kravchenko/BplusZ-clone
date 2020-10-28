using LightInject;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleGeneralDetails;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingServices
{
    public static class VehicleMappingModule
    {
        public static void RegisterVehicleMappers(this ServiceContainer container)
        {
            container.RegisterScoped<IVehicleMappingService, VehicleMappingService>();
            container.RegisterScoped<IVehicleGeneralMappingService, VehicleGeneralMappingService>();
            container.RegisterScoped<IVehicleFinanceMappingService, VehicleFinancelMappingService>();
            container.RegisterScoped<IVehicleTechnicalComponentsMappingService, VehicleTechnicalComponentsMappingService>();
            container.RegisterScoped<IVehicleTechnicalContractMappingService, VehicleTechnicalContractMappingService>();
            container.RegisterScoped<IVehicleTransferDataMappingService, VehicleTransferDataMappingService>();
            container.RegisterScoped<IUpdateVehicleMappingService, UpdateVehicleMappingService>();
        }
    }
}
