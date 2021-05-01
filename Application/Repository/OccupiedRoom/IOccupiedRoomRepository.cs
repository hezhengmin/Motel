using Application.Paging;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IOccupiedRoomRepository
    {
        Task<OccupiedRoom> GetOccupiedRoom(Guid id);
        Task<List<OccupiedRoom>> GetOccupiedRoomList();
        Task<PaginatedList<OccupiedRoom>> GetOccupiedRoomList(int pageNumber, int pageSize);
        Task<PaginatedList<OccupiedRoom>> GetOccupiedRoomList(string searchString, int pageNumber, int pageSize);
        Task AddOccupiedRoom(OccupiedRoom OccupiedRoom);
        Task UpdateOccupiedRoom(OccupiedRoom OccupiedRoom);
        Task RemoveOccupiedRoom(Guid id);
        bool GetOccupiedRoomExists(Guid id);
    }
}
