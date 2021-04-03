using AutoMapper;
using Infrastructure.Models;
using Application.Paging;
using Application.ViewModels.Room;
using System.Linq;
using Application.ViewModels.RoomType;

namespace Application.AutoMapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomViewModel>();

            CreateMap<RoomViewModel, Room>();

            CreateMap<PaginatedList<Room>, RoomIndexViewModel>()
                .ForMember(dest => dest.RoomViewModelList, opt => opt.MapFrom(src => src.ToList()))
                .AfterMap<MapRoomTypeCollectionAction>();
            //.AfterMap((src, dest) => dest.SearchString = "John");
            //.AfterMap((src, dest) => dest.RoomViewModelList.Select(m=>m.RoomTypeViewModel) = new RoomIndexViewModel());
            //.ForMember(dest => dest.RoomViewModelList.Select(m => m.RoomTypeViewModel), opt => opt.MapFrom(src => src.Select(m => m.RoomType)));
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
                //var room = source.Where(m=>m.Id=item.i).Select(c => c.Id).Intersect(destination.RoomViewModelList.Select(d => d.Id));

                if (source.Select(m => m.Id).Contains(item.Id))
                {
                    var roomType = source.Where(m => m.RoomType.Id == item.RoomTypeId).Select(m => m.RoomType).FirstOrDefault();
                    //var roomTypeViewModel = Mapper
                    //var roomTypeViewModel = Mapper.Map<RoomTypeViewModel>(roomType);
                    //var dest = Mapper.Map<RoomType, RoomTypeViewModel>(new RoomType { Area = 0 });

                    //item.RoomTypeViewModel = new RoomTypeViewModel()
                    //{
                    //    Id = roomType.Id,
                    //    Area = roomType.Area,
                    //    Price = roomType.Price,
                    //    Hprice = roomType.Hprice,
                    //    AirCondition = roomType.AirCondition,
                    //    BedQuantity = roomType.BedQuantity,
                    //    Name = roomType.Name,
                    //    Qk2price = roomType.Qk2price,
                    //    Qkprice = roomType.Qkprice,
                    //    Tv = roomType.Tv
                    //};


                    item.RoomTypeViewModel = _mapper.Map<RoomTypeViewModel>(roomType);

                }
            }

            destination.SearchString = "Sam";
        }
    }
}





