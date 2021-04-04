using Application.ViewModels.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IRoomService
    {
        Task<RoomViewModel> GetRoom(Guid id);
        Task<CompoundViewModel> GetAddOrEditRoom(Guid? id);
        Task<CompoundViewModel> GetAddOrEditRoom(CompoundViewModel compoundVM);
        Task<List<RoomViewModel>> GetRoomList();
        Task<RoomIndexViewModel> GetRoomList(int pageNumber, int pageSize);
        Task<RoomIndexViewModel> GetRoomList(FilterViewModel filterVM, int pageSize);
        Task<RoomIndexViewModel> GetRoomList(RoomDeleteViewModel RoomDeleteVM, int pageSize);
        Task<RoomIndexViewModel> GetRoomList(RoomIndexViewModel RoomIndexVM, int pageSize);
        Task AddRoom(RoomViewModel RoomVM);
        Task UpdateRoom(RoomViewModel RoomVM);
        Task RemoveRoom(Guid id);
        bool GetRoomExists(Guid id);
    }
}
