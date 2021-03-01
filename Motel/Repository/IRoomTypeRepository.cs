using Motel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Repository
{
    public interface IRoomTypeRepository
    {
        Task<RoomType> GetRoomType(Guid id);
        Task<List<RoomType>> GetRoomTypeList();
        Task AddRoomType(RoomType roomType);
        Task UpdateRoomType(RoomType roomType);
        Task RemoveRoomType(Guid id);
        bool GetRoomTypeExists(Guid id);
    }
}
