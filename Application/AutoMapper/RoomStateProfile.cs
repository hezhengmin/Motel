using AutoMapper;
using Infrastructure.Models;
using Application.ViewModels.RoomState;
using Application.Paging;
using System.Linq;


namespace Application.AutoMapper
{
    public class RoomStateProfile : Profile
    {
        public RoomStateProfile()
        {
            CreateMap<RoomState, RoomStateViewModel>();
            CreateMap<RoomStateViewModel, RoomState>();
        }
    }
}
