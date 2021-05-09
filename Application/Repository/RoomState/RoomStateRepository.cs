using Infrastructure.Data;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class RoomStateRepository : IRoomStateRepository
    {
        private readonly MotelDbContext _dbContext;

        public RoomStateRepository(MotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RoomState> GetRoomState(Guid id)
        {
            return await _dbContext.RoomState.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task AddRoomState(RoomState RoomState)
        {
            _dbContext.Add(RoomState);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoomState(RoomState RoomState)
        {
            _dbContext.Update(RoomState);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveRoomState(Guid id)
        {
            var RoomState = await this.GetRoomState(id);
            if (RoomState != null)
            {
                _dbContext.RoomState.Remove(RoomState);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
