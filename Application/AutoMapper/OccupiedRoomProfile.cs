using AutoMapper;
using Infrastructure.Models;
using Application.Paging;
using Application.ViewModels.OccupiedRoom;
using System.Linq;
using Application.Repository;

namespace Application.AutoMapper
{
    public class OccupiedRoomProfile : Profile
    {
        public OccupiedRoomProfile()
        {
            CreateMap<OccupiedRoom, OccupiedRoomViewModel>();

            CreateMap<OccupiedRoom, OccupiedRoomListViewModel>()
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.Room.RoomType.Name))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room.RoomNumber))
                .ForMember(dest => dest.BeginDate, opt => opt.MapFrom(src => src.Reservation.BeginDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.Reservation.EndDate))
                .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Reservation.Days))
                .ForMember(dest => dest.Expense, opt => opt.MapFrom(src => src.Reservation.Expense));

            CreateMap<OccupiedRoomViewModel, OccupiedRoom>();

            CreateMap<PaginatedList<OccupiedRoom>, OccupiedRoomIndexViewModel>()
                .ForMember(dest => dest.OccupiedRoomViewModelList, opt => opt.MapFrom(src => src.ToList()));

            CreateMap<OccupiedRoomDetailDTO, OccupiedRoomDetailViewModel>();
        }
    }
}
