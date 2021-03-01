using Microsoft.EntityFrameworkCore;
using Motel.Data;
using Motel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly MotelDbContext _dbContext;

        public RoomTypeRepository(MotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RoomType> GetRoomType(Guid id)
        {
            return await _dbContext.RoomType.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<RoomType>> GetRoomTypeList()
        {
            return await _dbContext.RoomType.ToListAsync();
        }

        public async Task AddRoomType(RoomType roomType)
        {
            _dbContext.Add(roomType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoomType(RoomType roomType)
        {
            _dbContext.Update(roomType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveRoomType(Guid id)
        {
            var roomType = await GetRoomType(id);
            if (roomType != null)
            {
                _dbContext.RoomType.Remove(roomType);
                await _dbContext.SaveChangesAsync();
            }
        }

        public bool GetRoomTypeExists(Guid id)
        {
            return _dbContext.RoomType.Any(m => m.Id == id);
        }
    }
}
