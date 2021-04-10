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
            return await _dbContext.RoomType.OrderByDescending(m => m.SysDate).ToListAsync();
        }

        public async Task<PaginatedList<RoomType>> GetRoomTypeList(int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<RoomType>().AsQueryable();

            query = query.OrderByDescending(m => m.SysDate);

            var list = await PaginatedList<RoomType>.CreateAsync(query, pageNumber, pageSize);
            
            return list;
        }

        public async Task<PaginatedList<RoomType>> GetRoomTypeList(string searchString, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<RoomType>().AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.Name.Contains(searchString));
            }

            query = query.OrderByDescending(m => m.SysDate);

            var list = await PaginatedList<RoomType>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task AddRoomType(RoomType RoomType)
        {
            RoomType.SysDate = DateTime.Now;
            _dbContext.Add(RoomType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoomType(RoomType RoomType)
        {
            _dbContext.Update(RoomType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveRoomType(Guid id)
        {
            var RoomType = await GetRoomType(id);
            if (RoomType != null)
            {
                _dbContext.RoomType.Remove(RoomType);
                await _dbContext.SaveChangesAsync();
            }
        }

        public bool GetRoomTypeExists(Guid id)
        {
            return _dbContext.RoomType.Any(m => m.Id == id);
        }
    }
}
