using AutoMapper;
using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Mapping;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails.Dtos;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.UpdateVehicleDetails
{
    public class UpdateVehicleMappingService : RolesBasedMappingService<UpdateVehicleDetailsDto>, IUpdateVehicleMappingService
    {
        public override MapperConfiguration CreateMapperConfiguration<TEntity>(UpdateVehicleDetailsDto source, string role, ActionType actionType)
            where TEntity : class
        {
            var generalDataCondition = GetMapperCondition(role, actionType);
            var technicalComponentsCondition = GetMapperCondition(role, actionType);
            var technicalContractCondition = GetMapperCondition(role, actionType);
            var transferDataCondition = GetMapperCondition(role, actionType);
            var mainCondition = GetMapperCondition(role, actionType);

            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GeneralDataDto, GeneralData>()
                    .ReverseMap()
                    .ForAllMembers(opts => opts.Condition(generalDataCondition));

                cfg.CreateMap<TechnicalComponentsDto, TechnicalComponents>()
                    .ReverseMap()
                    .ForAllMembers(opts => opts.Condition(technicalComponentsCondition));

                cfg.CreateMap<TechnicalContractDataDto, TechnicalContractData>()
                    .ReverseMap()
                    .ForAllMembers(opts => opts.Condition(technicalContractCondition));

                cfg.CreateMap<TransferDataDto, TransferData>()
                    .ReverseMap()
                    .ForAllMembers(opts => opts.Condition(transferDataCondition));

                cfg.CreateMap<UpdateVehicleDetailsDto, TEntity>()
                    .ReverseMap()
                    .ForAllMembers(opts => opts.Condition(mainCondition));
            });
        }
    }
}
