using AutoMapper;
using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Mapping;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingModels;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingServices
{
    public class VehicleTechnicalContractMappingService : RolesBasedMappingService<Vehicle>, IVehicleTechnicalContractMappingService
    {
        public override MapperConfiguration CreateMapperConfiguration<TEntity>(Vehicle source, string role, ActionType actionType)
        {
            var technicalContractCondition = GetMapperCondition(role, actionType);

            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vehicle, TEntity>()
                    .IncludeMembers(v => v.TechnicalContractData);

                cfg.CreateMap<TechnicalContractData, VehicleTechnicalContractDetailsDto>(MemberList.Source)
                    .ForAllMembers(opts => opts.Condition(technicalContractCondition));
            });
        }
    }
}
