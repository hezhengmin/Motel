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
            CreateMap<Reservation, ReservationViewModel>();

            CreateMap<ReservationViewModel, Reservation>();

            CreateMap<PaginatedList<Reservation>, ReservationIndexViewModel>()
                .ForMember(dest => dest.ReservationViewModelList, opt => opt.MapFrom(src => src.ToList()));
        }
    }
}
