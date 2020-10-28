using AutoMapper;
using Synnotech_BplusZ.WebApi.Vehicles.DatabaseModel;

namespace Synnotech_BplusZ.WebApi.Vehicles.VehiclesList.GetVehiclesStock
{
    public class VehicleStockProfile : Profile
    {
        public VehicleStockProfile()
        {
            CreateMap<VehiclePagedResult, VehicleStockPagedResultDto>();
            CreateMap<Vehicle, VehicleStockResultDto>(MemberList.Destination)
                .IncludeMembers(v => v.GeneralData, v => v.TransferData, v => v.TechnicalComponents);
            CreateMap<GeneralData, VehicleStockResultDto>();
            CreateMap<TransferData, VehicleStockResultDto>();
            CreateMap<TechnicalComponents, VehicleStockResultDto>();
        }
    }
}
