using AutoMapper;
using Synnotech_BplusZ.WebApi.Attributes;
using Synnotech_BplusZ.WebApi.Mapping;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.GetVehicleGeneralDetails;
using Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingModels;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehicleDetails.VehicleMappingServices
{
    public class VehicleGeneralMappingService : RolesBasedMappingService<Vehicle>, IVehicleGeneralMappingService
    {
        public override MapperConfiguration CreateMapperConfiguration<TEntity>(Vehicle source, string role, ActionType actionType)
        {
            var generalDataCondition = GetMapperCondition(role, actionType);

            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vehicle, TEntity>()
                    .IncludeMembers(v => v.GeneralData);

                cfg.CreateMap<GeneralData, VehicleGeneralDetailsDto>(MemberList.Source)
                    .ForAllMembers(opts => opts.Condition(generalDataCondition));
            });
        }
    }
}
