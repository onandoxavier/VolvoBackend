using AutoMapper;
using Volvo.API.Domain.Entities;
using Volvo.API.Domain.Models.Results;
using Volvo.API.Utils.Extensions;

namespace Volvo.API.Domain.Models.Profiles
{
    public class TruckProfile : Profile
    {
        public TruckProfile()
        {
            MapEntityToDTO();
        }
        private void MapEntityToDTO()
        {
            CreateMap<Truck, TruckListResult>()
                .ForMember(dto => dto.Chassis, map => map.MapFrom(x => x.Chassis != null ? x.Chassis.ToString() : string.Empty))
                .ForMember(dto => dto.Color, map => map.MapFrom(x => x.Color.ToString()))
                .ForMember(dto => dto.Model, map => map.MapFrom(x => x.ModelType.GetDescription()))
                .ForMember(dto => dto.Plan, map => map.MapFrom(x => x.Plan.GetDescription()));

            CreateMap<Truck, TruckResult>()
                .ForMember(dto => dto.Chassis, map => map.MapFrom(x => x.Chassis != null ? x.Chassis.ToString() : string.Empty))
                .ForMember(dto => dto.Color, map => map.MapFrom(x => x.Color.ToString()))
                .ForMember(dto => dto.Model, map => map.MapFrom(x => x.ModelType.GetDescription()))
                .ForMember(dto => dto.ModelId, map => map.MapFrom(x => x.ModelType))
                .ForMember(dto => dto.Plan, map => map.MapFrom(x => x.Plan.GetDescription()))
                .ForMember(dto => dto.PlanId, map => map.MapFrom(x => x.Plan));
        }
    }
}
