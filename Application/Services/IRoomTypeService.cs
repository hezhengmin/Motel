using Application.ViewModels.RoomType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IRoomTypeService
    {
        Task<RoomTypeViewModel> GetRoomType(Guid id);
        Task<List<RoomTypeViewModel>> GetRoomTypeList();
        Task<RoomTypeIndexViewModel> GetRoomTypeList(int pageNumber, int pageSize);
        Task<RoomTypeIndexViewModel> GetRoomTypeList(FilterViewModel filterVM, int pageSize);
        Task<RoomTypeIndexViewModel> GetRoomTypeList(RoomTypeDeleteViewModel roomTypeDeleteVM, int pageSize);
        Task<RoomTypeIndexViewModel> GetRoomTypeList(RoomTypeIndexViewModel roomTypeIndexVM, int pageSize);
        Task AddRoomType(RoomTypeViewModel roomTypeVM);
        Task UpdateRoomType(RoomTypeViewModel roomTypeVM);
        Task RemoveRoomType(Guid id);
        bool GetRoomTypeExists(Guid id);
    }
}
