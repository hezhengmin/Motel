using Application.Paging;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IRoomTypeRepository
    {
        Task<RoomType> GetRoomType(Guid id);
        Task<List<RoomType>> GetRoomTypeList();
        Task<PaginatedList<RoomType>> GetRoomTypeList(int pageNumber, int pageSize);
        Task<PaginatedList<RoomType>> GetRoomTypeList(string searchString, int pageNumber, int pageSize);
        Task AddRoomType(RoomType roomType);
        Task UpdateRoomType(RoomType roomType);
        Task RemoveRoomType(Guid id);
        bool GetRoomTypeExists(Guid id);
    }
}
