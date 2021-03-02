using Motel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Services
{
    public interface IRoomTypeService
    {
        Task<RoomTypeViewModel> GetRoomType(Guid id);
        Task<List<RoomTypeViewModel>> GetRoomTypeList();
        Task AddRoomType(RoomTypeViewModel roomTypeVM);
        Task UpdateRoomType(RoomTypeViewModel roomTypeVM);
        Task RemoveRoomType(Guid id);
        bool GetRoomTypeExists(Guid id);
    }
}
