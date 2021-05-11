using Application.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IReservationService
    {
        Task<ReservationViewModel> GetReservation(Guid id);
        Task<CompoundReservationViewModel> GetAddOrEditReservation(Guid? id, Guid customerId);
        Task<CompoundReservationViewModel> GetAddOrEditReservation(CompoundReservationViewModel compoundVM);
        Task<List<ReservationViewModel>> GetReservationList();
        Task<ReservationIndexViewModel> GetReservationList(Guid customerId, int pageNumber, int pageSize);
        Task<ReservationIndexViewModel> GetReservationList(Guid customerId, FilterViewModel filterVM, int pageSize);
        Task<ReservationIndexViewModel> GetReservationList(CompoundReservationViewModel compoundVM, int pageSize);
        Task<ReservationIndexViewModel> GetReservationList(ReservationDeleteViewModel ReservationDeleteVM, int pageSize);
        Task<ReservationIndexViewModel> GetReservationList(ReservationIndexViewModel ReservationIndexVM, int pageSize);
        Task<ReservationIndexViewModel> GetReservationList(Guid customerId, ReservationIndexViewModel ReservationIndexVM, int pageSize);
        Task<ReservationViewModel> GetReservationExpense(ReservationExpenseViewModel expenseViewModel);
        Task<bool> GetReservationDateIsOverlapAsync(ReservationViewModel reservationVM);
        Task AddReservation(ReservationViewModel ReservationVM);
        Task UpdateReservation(ReservationViewModel ReservationVM);
        Task RemoveReservation(Guid id);
        bool GetReservationExists(Guid id);
    }
}
