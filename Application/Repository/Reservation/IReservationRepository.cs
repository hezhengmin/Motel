using Application.Paging;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IReservationRepository
    {
        Task<Reservation> GetReservation(Guid id);
        Task<List<Reservation>> GetReservationList();
        Task<PaginatedList<Reservation>> GetReservationList(int pageNumber, int pageSize);
        Task<PaginatedList<Reservation>> GetReservationList(string searchString, int pageNumber, int pageSize);
        Task AddReservation(Reservation Reservation);
        Task UpdateReservation(Reservation Reservation);
        Task RemoveReservation(Guid id);
        bool GetReservationExists(Guid id);
    }
}
