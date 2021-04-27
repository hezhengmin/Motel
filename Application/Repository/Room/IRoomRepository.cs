using Application.Paging;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IRoomRepository
    {
        Task<Room> GetRoom(Guid id);
        Task<List<Room>> GetRoomList();
        Task<List<Room>> GetRoomList(Guid roomTypeId);
        Task<PaginatedList<Room>> GetRoomList(int pageNumber, int pageSize);
        Task<PaginatedList<Room>> GetRoomList(string searchString, int pageNumber, int pageSize);
        Task AddRoom(Room Room);
        Task UpdateRoom(Room Room);
        Task RemoveRoom(Guid id);
        bool GetRoomExists(Guid id);
    }
}
