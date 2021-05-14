using Application.Paging;
using Application.Repository.ReservationEnums;
using Infrastructure.Data;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly MotelDbContext _dbContext;

        public ReservationRepository(MotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Reservation> GetReservation(Guid id)
        {
            return await _dbContext.Reservation.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Reservation> GetMultipleEntitiesReservation(Guid id)
        {
            return await _dbContext.Reservation.Include(m => m.Room).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<ReservationDetailDTO> GetReservationDetailDTO(Guid id)
        {
            ReservationDetailDTO reservationDetailDTO = new ReservationDetailDTO();
            var query = _dbContext.Set<Reservation>().AsQueryable();
            var queryRoom = _dbContext.Set<Room>().AsQueryable();
            var queryRoomType = _dbContext.Set<RoomType>().AsQueryable();
            var queryCustomer = _dbContext.Set<Customer>().AsQueryable();
            var queryOccupiedRoom = _dbContext.Set<OccupiedRoom>().AsQueryable();

            reservationDetailDTO = await query.GroupJoin(queryOccupiedRoom, 
                                                         reservation => reservation.Id, 
                                                         occupiedRoom => occupiedRoom.Id, 
                                                        (reservation, occupiedRoom) => new { Reservation = reservation, OccupiedRoom = occupiedRoom })
                                              .SelectMany(combination => combination.OccupiedRoom.DefaultIfEmpty(),
                                                         (parent, occupiedRoom) => new { Reservation = parent.Reservation, OccupiedRoom = occupiedRoom })
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
                                              .Select(m => new ReservationDetailDTO
                                              {
                                                  Id = m.Reservation.Id,
                                                  CustomerId = m.Customer.Id,
                                                  RoomId = m.Room.Id,
                                                  RoomNumber = m.Room.RoomNumber,
                                                  RoomTypeName = m.RoomType.Name,
                                                  CustomerName = m.Customer.Name,
                                                  CheckInDate = m.OccupiedRoom.CheckInDate,
                                                  CheckOutDate = m.OccupiedRoom.CheckOutDate,
                                                  Pay = m.OccupiedRoom.Pay,
                                                  Days = m.OccupiedRoom.Days,
                                                  Balance = m.OccupiedRoom.Balance
                                              }).FirstOrDefaultAsync(m => m.Id == id);

            return reservationDetailDTO;
        }

        public async Task<List<Reservation>> GetReservationList()
        {
            return await _dbContext.Reservation.OrderByDescending(m => m.SysDate).ToListAsync();
        }

        public async Task<PaginatedList<Reservation>> GetReservationList(Guid customerId, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Reservation>().AsQueryable();

            query = query.Include(m => m.Room)
                         .ThenInclude(m => m.RoomType);

            query = query.Where(m => m.CustomerId == customerId).OrderByDescending(m => m.SysDate);

            var list = await PaginatedList<Reservation>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task<PaginatedList<Reservation>> GetReservationList(int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Reservation>().AsQueryable();

            query = query.Include(m => m.Room)
                         .ThenInclude(m => m.RoomType);

            query = query.OrderByDescending(m => m.BeginDate).ThenByDescending(m => m.SysDate);

            var list = await PaginatedList<Reservation>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task<PaginatedList<Reservation>> GetReservationList(string searchString, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Reservation>().AsQueryable();

            query = query.Include(m => m.Room)
                         .ThenInclude(m => m.RoomType);

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.Room.RoomNumber.Contains(searchString));
            }

            query = query.OrderByDescending(m => m.SysDate);

            var list = await PaginatedList<Reservation>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task<PaginatedList<Reservation>> GetReservationList(Guid customerId, string searchString, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Reservation>().AsQueryable();

            query = query.Include(m => m.Room)
                         .ThenInclude(m => m.RoomType);

            query = query.Where(m => m.CustomerId == customerId);

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.Room.RoomNumber.Contains(searchString));
            }

            query = query.OrderByDescending(m => m.SysDate);

            var list = await PaginatedList<Reservation>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task<PaginatedList<Reservation>> GetReservationList(ReservationSearchField searchField, string searchString, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Reservation>().AsQueryable();

            query = query.Include(m => m.Customer)
                         .Include(m => m.Room)
                         .ThenInclude(m => m.RoomType);


            switch (searchField)
            {
                case ReservationSearchField.RoomNumber:
                    if (!string.IsNullOrEmpty(searchString))
                    {
                        query = query.Where(m => m.Room.RoomNumber.Contains(searchString));
                    }
                    break;
                case ReservationSearchField.CustomerName:
                    if (!string.IsNullOrEmpty(searchString))
                    {
                        query = query.Where(m => m.Customer.Name.Contains(searchString));
                    }
                    break;
            }

            query = query.OrderByDescending(m => m.BeginDate).ThenByDescending(m => m.SysDate);

            var list = await PaginatedList<Reservation>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }
        public async Task<bool> GetReservationDateIsOverlap(Guid roomId, DateTime beginDate, DateTime endDate)
        {
            var query = _dbContext.Set<Reservation>().AsQueryable();
            bool result = await query.Where(m => m.RoomId == roomId).AnyAsync(m => (m.EndDate >= beginDate && m.BeginDate <= endDate));

            return result;
        }

        public async Task<bool> GetReservationDateIsOverlap(Guid id, Guid roomId, DateTime beginDate, DateTime endDate)
        {
            var query = _dbContext.Set<Reservation>().AsQueryable();
            query = query.Where(m => m.Id != id);

            bool result = await query.Where(m => m.RoomId == roomId).AnyAsync(m => (m.EndDate >= beginDate && m.BeginDate <= endDate));

            return result;
        }

        public async Task AddReservation(Reservation reservation)
        {
            reservation.SysDate = DateTime.Now;
            _dbContext.Add(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            _dbContext.Update(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveReservation(Guid id)
        {
            var reservation = await GetReservation(id);
            if (reservation != null)
            {
                _dbContext.Reservation.Remove(reservation);
                await _dbContext.SaveChangesAsync();
            }
        }

        public bool GetReservationExists(Guid id)
        {
            return _dbContext.Reservation.Any(m => m.Id == id);
        }
    }
}
