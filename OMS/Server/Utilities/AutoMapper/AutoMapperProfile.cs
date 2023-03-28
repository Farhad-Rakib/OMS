using AutoMapper;
using Core.Entities;
using OMS.Shared.DTO;

namespace OMS.Server.Utilities.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.Windows, opt => opt.MapFrom(src => src.Windows)).ReverseMap();
            CreateMap<Window, WindowDTO>()
                .ForMember(dest => dest.SubElements, opt => opt.MapFrom(src => src.subElements)).ReverseMap();
            CreateMap<SubElement, SubElementDTO>().ReverseMap();
        }
    }
}
