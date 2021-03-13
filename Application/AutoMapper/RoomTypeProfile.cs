using AutoMapper;
using Infrastructure.Models;
using Application.ViewModels;

namespace Application.AutoMapper
{
    public class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<RoomType, RoomTypeViewModel>();
            CreateMap<RoomTypeViewModel, RoomType>();
        }
    }
}
