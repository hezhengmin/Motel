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

            query = query.Include(m => m.Reservation)
                         .Include(m => m.Room)
                         .ThenInclude(m => m.RoomType);

            query = query.OrderByDescending(m => m.Reservation.BeginDate).ThenByDescending(m => m.SysDate);

            var list = await PaginatedList<OccupiedRoom>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task<PaginatedList<OccupiedRoom>> GetOccupiedRoomList(string searchString, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<OccupiedRoom>().AsQueryable();

            query = query.Include(m => m.Reservation)
                         .Include(m => m.Room)
                         .ThenInclude(m => m.RoomType);

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.Room.RoomNumber.Contains(searchString));
            }

            query = query.OrderByDescending(m => m.Reservation.BeginDate).ThenByDescending(m => m.SysDate);

            var list = await PaginatedList<OccupiedRoom>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task<OccupiedRoomDetailDTO> GetOccupiedRoomDetailDTO(Guid id)
        {
            OccupiedRoomDetailDTO occupiedRoomDetailDTO = new OccupiedRoomDetailDTO();
            var query = _dbContext.Set<Reservation>().AsQueryable();
            var queryRoom = _dbContext.Set<Room>().AsQueryable();
            var queryRoomType = _dbContext.Set<RoomType>().AsQueryable();
            var queryCustomer = _dbContext.Set<Customer>().AsQueryable();
            var queryOccupiedRoom = _dbContext.Set<OccupiedRoom>().AsQueryable();

            occupiedRoomDetailDTO = await query.Join(queryOccupiedRoom,
                                                     reservation => reservation.Id,
                                                     occupiedRoom => occupiedRoom.Id,
                                                    (reservation, occupiedRoom) => new { Reservation = reservation, OccupiedRoom = occupiedRoom })
                                               .Join(queryRoom,
                                                     parent => parent.Reservation.RoomId,
                                                     room => room.Id,
                                                    (parent, room) => new { Reservation = parent.Reservation, OccupiedRoom = parent.OccupiedRoom, Room = room })
                                               .Join(queryRoomType,
                                                     parent => parent.Room.RoomTypeId,
                                                     roomType => roomType.Id,
                                                    (parent, roomType) => new { Reservation = parent.Reservation, OccupiedRoom = parent.OccupiedRoom, Room = parent.Room, RoomType = roomType })
                                               .Join(queryCustomer,
                                                     parent => parent.Reservation.CustomerId,
                                                     customer => customer.Id,
                                                    (parent, customer) => new { Reservation = parent.Reservation, OccupiedRoom = parent.OccupiedRoom, Room = parent.Room, RoomType = parent.RoomType, Customer = customer })
                                               .Select(m => new OccupiedRoomDetailDTO
                                               {
                                                   Id = m.OccupiedRoom.Id,
                                                   CustomerId = m.OccupiedRoom.CustomerId,
                                                   RoomId = m.OccupiedRoom.RoomId,
                                                   RoomNumber = m.Room.RoomNumber,
                                                   RoomTypeName = m.RoomType.Name,
                                                   BeginDate = m.Reservation.BeginDate,
                                                   EndDate = m.Reservation.EndDate,
                                                   CustomerName = m.Customer.Name,
                                                   Expense = m.Reservation.Expense,
                                                   CheckInDate = m.OccupiedRoom.CheckInDate,
                                                   CheckOutDate = m.OccupiedRoom.CheckOutDate,
                                                   Pay = m.OccupiedRoom.Pay,
                                               }).FirstOrDefaultAsync(m => m.Id == id);

            return occupiedRoomDetailDTO;
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
