using AutoMapper;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesAdvance
{
    public class VehicleAdvanceProfile : Profile
    {
        public VehicleAdvanceProfile()
        {
            CreateMap<VehiclePagedResult, VehicleAdvancePagedResultDto>();
            CreateMap<Vehicle, VehicleAdvanceResultDto>(MemberList.Destination)
                .IncludeMembers(v => v.GeneralData, v => v.TransferData, v => v.TechnicalComponents);
            CreateMap<GeneralData, VehicleAdvanceResultDto>();
            CreateMap<TransferData, VehicleAdvanceResultDto>();
            CreateMap<TechnicalComponents, VehicleAdvanceResultDto>();
        }
    }
}
