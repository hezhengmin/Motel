using Application.Paging;
using Application.Repository.ReservationEnums;
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
        Task<Reservation> GetMultipleEntitiesReservation(Guid id);
        Task<List<Reservation>> GetReservationList();
        Task<PaginatedList<Reservation>> GetReservationList(int pageNumber, int pageSize);
        Task<PaginatedList<Reservation>> GetReservationList(Guid customerId, int pageNumber, int pageSize);
        Task<PaginatedList<Reservation>> GetReservationList(string searchString, int pageNumber, int pageSize);
        Task<PaginatedList<Reservation>> GetReservationList(Guid customerId, string searchString, int pageNumber, int pageSize);
        Task<PaginatedList<Reservation>> GetReservationList(ReservationSearchField searchField, string searchString, int pageNumber, int pageSize);
        Task<bool> GetReservationDateIsOverlap(Guid roomId, DateTime beginDate, DateTime endDate);
        Task<bool> GetReservationDateIsOverlap(Guid id,Guid roomId, DateTime beginDate, DateTime endDate);
        Task AddReservation(Reservation Reservation);
        Task UpdateReservation(Reservation Reservation);
        Task RemoveReservation(Guid id);
        bool GetReservationExists(Guid id);
    }
}
