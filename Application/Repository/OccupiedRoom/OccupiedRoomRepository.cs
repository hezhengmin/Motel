using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Models;
using Application.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class OccupiedRoomRepository : IOccupiedRoomRepository
    {
        private readonly MotelDbContext _dbContext;

        public OccupiedRoomRepository(MotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OccupiedRoom> GetOccupiedRoom(Guid id)
        {
            return await _dbContext.OccupiedRoom.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<OccupiedRoom>> GetOccupiedRoomList()
        {
            return await _dbContext.OccupiedRoom.OrderByDescending(m => m.SysDate).ToListAsync();
        }

        public async Task<PaginatedList<OccupiedRoom>> GetOccupiedRoomList(int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<OccupiedRoom>().AsQueryable();

            query = query.OrderByDescending(m => m.SysDate);

            var list = await PaginatedList<OccupiedRoom>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task<PaginatedList<OccupiedRoom>> GetOccupiedRoomList(string searchString, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<OccupiedRoom>().Include(m => m.Room).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.Room.RoomNumber.Contains(searchString));
            }

            query = query.OrderByDescending(m => m.SysDate);

            var list = await PaginatedList<OccupiedRoom>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task AddOccupiedRoom(OccupiedRoom OccupiedRoom)
        {
            OccupiedRoom.SysDate = DateTime.Now;
            _dbContext.Add(OccupiedRoom);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateOccupiedRoom(OccupiedRoom OccupiedRoom)
        {
            _dbContext.Update(OccupiedRoom);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveOccupiedRoom(Guid id)
        {
            var OccupiedRoom = await GetOccupiedRoom(id);
            if (OccupiedRoom != null)
            {
                _dbContext.OccupiedRoom.Remove(OccupiedRoom);
                await _dbContext.SaveChangesAsync();
            }
        }

        public bool GetOccupiedRoomExists(Guid id)
        {
            return _dbContext.OccupiedRoom.Any(m => m.Id == id);
        }
    }
}
