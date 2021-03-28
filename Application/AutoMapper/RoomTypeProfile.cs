using AutoMapper;
using Infrastructure.Models;
using Application.ViewModels.RoomType;
using Application.Paging;
using System.Linq;

namespace Application.AutoMapper
{
    public class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<RoomType, RoomTypeViewModel>();
            CreateMap<RoomTypeViewModel, RoomType>();
            CreateMap<PaginatedList<RoomType>, RoomTypeIndexViewModel>()
                .ForMember(dest => dest.RoomTypeViewModelList, opt => opt.MapFrom(src => src.ToList()));
        }
    }
}
