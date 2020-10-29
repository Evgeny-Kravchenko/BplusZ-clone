using AutoMapper;
using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Mapping;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingModels;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingServices
{
    public class VehicleTransferDataMappingService : RolesBasedMappingService<Vehicle>, IVehicleTransferDataMappingService
    {
        public override MapperConfiguration CreateMapperConfiguration<TEntity>(Vehicle source, string role, ActionType actionType)
        {
            var transferDataCondition = GetMapperCondition(role, actionType);

            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vehicle, TEntity>()
                    .IncludeMembers(v => v.TransferData);

                cfg.CreateMap<TransferData, VehicleTransferDataDto>(MemberList.Source)
                    .ForAllMembers(opts => opts.Condition(transferDataCondition));
            });
        }
    }
}
