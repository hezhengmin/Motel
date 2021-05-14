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

            CreateMap<OccupiedRoomViewModel, OccupiedRoom>();

            CreateMap<PaginatedList<OccupiedRoom>, OccupiedRoomIndexViewModel>()
                .ForMember(dest => dest.OccupiedRoomViewModelList, opt => opt.MapFrom(src => src.ToList()));

            CreateMap<ReservationDetailDTO, OccupiedRoomDetailViewModel>();
        }
    }
}
