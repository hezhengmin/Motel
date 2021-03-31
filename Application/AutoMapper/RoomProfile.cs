using AutoMapper;
using Infrastructure.Models;
using Application.Paging;
using Application.ViewModels.Room;
using System.Linq;

namespace Application.AutoMapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomViewModel>();
            
            CreateMap<RoomViewModel, Room>();
          
            CreateMap<PaginatedList<Room>, RoomIndexViewModel>()
                .ForMember(dest => dest.RoomViewModelList, opt => opt.MapFrom(src => src.ToList()));
        }
    }
}





