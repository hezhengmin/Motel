using AutoMapper;
using Infrastructure.Models;
using Application.Paging;
using Application.ViewModels.Room;
using System.Linq;
using Application.ViewModels.RoomType;
using Application.ViewModels.RoomState;

namespace Application.AutoMapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomViewModel>()
                .AfterMap((src, dest) => dest.RoomStateViewModel = new RoomStateViewModel
            {
                Id = src.RoomState.Id,
                     StateType = src.RoomState.StateType
                 });

            CreateMap<RoomViewModel, Room>();

            CreateMap<PaginatedList<Room>, RoomIndexViewModel>()
                .ForMember(dest => dest.RoomViewModelList, opt => opt.MapFrom(src => src.ToList()))
                .AfterMap<MapRoomTypeCollectionAction>();
        }
    }

    public class MapRoomTypeCollectionAction : IMappingAction<PaginatedList<Room>, RoomIndexViewModel>
    {
        private readonly IMapper _mapper;

        public MapRoomTypeCollectionAction(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Process(PaginatedList<Room> source, RoomIndexViewModel destination, ResolutionContext context)
        {
            foreach (var item in destination.RoomViewModelList)
            {
                if (source.Select(m => m.Id).Contains(item.Id))
                {
                    var roomType = source.Where(m => m.RoomType.Id == item.RoomTypeId).Select(m => m.RoomType).FirstOrDefault();
                    item.RoomTypeViewModel = _mapper.Map<RoomTypeViewModel>(roomType);
                }
            }
        }
    }
}





