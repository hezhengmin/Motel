using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Models;
using Application.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Enums;

namespace Application.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MotelDbContext _dbContext;

        public RoomRepository(MotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Room> GetRoom(Guid id)
        {
            return await _dbContext.Room.Include(m => m.RoomType)
                                        .Include(m=>m.RoomState)
                                        .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Room>> GetRoomList()
        {
            return await _dbContext.Room.Include(m => m.RoomType)
                                        .Include(m => m.RoomState)
                                        .OrderByDescending(m => m.SysDate).ToListAsync();
        }

        public async Task<List<Room>> GetRoomList(Guid? roomTypeId)
        {
            var query = _dbContext.Set<Room>().AsQueryable();

            if (roomTypeId.HasValue)
            {
                query = query.Where(m => m.RoomTypeId == roomTypeId.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<List<Room>> GetRoomList(Guid roomTypeId)
        {
            return await _dbContext.Room.Where(m => m.RoomTypeId == roomTypeId).ToListAsync();
        }

        public async Task<PaginatedList<Room>> GetRoomList(int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Room>().Include(m => m.RoomType)
                                              .Include(m => m.RoomState)
                                              .AsQueryable();

            query = query.OrderByDescending(m => m.SysDate);

            var list = await PaginatedList<Room>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task<PaginatedList<Room>> GetRoomList(string searchString, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Room>().Include(m => m.RoomType)
                                              .Include(m => m.RoomState)
                                              .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.RoomNumber.Contains(searchString));
            }

            query = query.OrderByDescending(m => m.SysDate);

            var list = await PaginatedList<Room>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task AddRoom(Room Room)
        {
            Room.SysDate = DateTime.Now;

            _dbContext.Add(Room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoom(Room Room)
        {
            _dbContext.Update(Room);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveRoom(Guid id)
        {
            var room = await _dbContext.Set<Room>().Include(m => m.RoomState)
                                                   .FirstOrDefaultAsync(m => m.Id == id);

            if (room != null)
            {
                _dbContext.RoomState.Remove(room.RoomState);
                _dbContext.Room.Remove(room);
                await _dbContext.SaveChangesAsync();
            }
        }

        public bool GetRoomExists(Guid id)
        {
            return _dbContext.Room.Any(m => m.Id == id);
        }
    }
}
