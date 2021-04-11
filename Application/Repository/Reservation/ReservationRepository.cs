﻿using Application.Paging;
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

        public async Task<List<Reservation>> GetReservationList()
        {
            return await _dbContext.Reservation.OrderByDescending(m => m.SysDate).ToListAsync();
        }

        public async Task<PaginatedList<Reservation>> GetReservationList(Guid customerId, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Reservation>().AsQueryable();

            query = query.Where(m => m.CustomerId == customerId).OrderByDescending(m => m.SysDate);

            var list = await PaginatedList<Reservation>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task<PaginatedList<Reservation>> GetReservationList(int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Reservation>().AsQueryable();

            query = query.OrderByDescending(m => m.SysDate);

            var list = await PaginatedList<Reservation>.CreateAsync(query, pageNumber, pageSize);

            return list;
        }

        public async Task<PaginatedList<Reservation>> GetReservationList(string searchString, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Reservation>().AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.Room.RoomNumber.Contains(searchString));
            }

            query = query.OrderByDescending(m => m.SysDate);

            var list = await PaginatedList<Reservation>.CreateAsync(query, pageNumber, pageSize);

            return list;
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
