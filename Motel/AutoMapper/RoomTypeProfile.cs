using AutoMapper;
using Motel.Models;
using Motel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.AutoMapper
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
