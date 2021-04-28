using AutoMapper;
using Infrastructure.Models;
using Application.Paging;
using Application.ViewModels.Reservation;
using System.Linq;

namespace Application.AutoMapper
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationViewModel>()
                .ForMember(dest => dest.RoomTypeId, opt => opt.MapFrom(src => src.Room.RoomTypeId));

            CreateMap<Reservation, ReservationListViewModel>()
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.Room.RoomType.Name))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room.RoomNumber));

            CreateMap<ReservationViewModel, Reservation>();

            CreateMap<PaginatedList<Reservation>, ReservationIndexViewModel>()
                .ForMember(dest => dest.ReservationViewModelList, opt => opt.MapFrom(src => src.ToList()));
        }
    }
}
