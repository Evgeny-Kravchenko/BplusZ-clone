using AutoMapper;
using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Mapping;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingServices
{
    public class VehicleMappingService : RolesBasedMappingService<Vehicle>, IVehicleMappingService
    {
        public override MapperConfiguration CreateMapperConfiguration<TEntity>(Vehicle source, string role, ActionType actionType)
        {
            var generalDataCondition = GetMapperCondition(role, actionType);
            var technicalComponentsCondition = GetMapperCondition(role, actionType);
            var technicalContractCondition = GetMapperCondition(role, actionType);
            var transferDataCondition = GetMapperCondition(role, actionType);
            var financeCondition = GetMapperCondition(role, actionType);
            var mainCondition = GetMapperCondition(role, actionType);

            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GeneralData, GeneralData>()
                    .ForAllMembers(opts => opts.Condition(generalDataCondition));
                cfg.CreateMap<TechnicalComponents, TechnicalComponents>()
                    .ForAllMembers(opts => opts.Condition(technicalComponentsCondition));
                cfg.CreateMap<TechnicalContractData, TechnicalContractData>()
                    .ForAllMembers(opts => opts.Condition(technicalContractCondition));
                cfg.CreateMap<TransferData, TransferData>()
                    .ForAllMembers(opts => opts.Condition(transferDataCondition));
                cfg.CreateMap<Finance, Finance>()
                    .ForAllMembers(opts => opts.Condition(financeCondition));

                cfg.CreateMap<Vehicle, TEntity>()
                    .ForAllMembers(opts => opts.Condition(mainCondition));
            });
        }
    }
}
