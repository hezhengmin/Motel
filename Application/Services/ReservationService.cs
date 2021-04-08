using Application.Repository;
using Infrastructure.Models;
using Application.ViewModels.Reservation;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IMapper mapper, IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }

        public async Task<ReservationViewModel> GetReservation(Guid id)
        {
            return _mapper.Map<ReservationViewModel>(await _reservationRepository.GetReservation(id));
        }

        public async Task<List<ReservationViewModel>> GetReservationList()
        {
            return _mapper.Map<List<ReservationViewModel>>(await _reservationRepository.GetReservationList());
        }

        public async Task<ReservationIndexViewModel> GetReservationList(int pageNumber, int pageSize)
        {
            var query = _mapper.Map<ReservationIndexViewModel>(await _reservationRepository.GetReservationList(pageNumber, pageSize));
            return query;
        }

        public async Task<ReservationIndexViewModel> GetReservationList(FilterViewModel filterVM, int pageSize)
        {
            var pageNumber = filterVM.PageNumber == 0 ? 1 : filterVM.PageNumber;
            var query = _mapper.Map<ReservationIndexViewModel>(await _reservationRepository.GetReservationList(filterVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(filterVM.SearchString))
                query.SearchString = filterVM.SearchString;

            return query;
        }

        public async Task<ReservationIndexViewModel> GetReservationList(ReservationIndexViewModel ReservationIndexVM, int pageSize)
        {
            var pageNumber = ReservationIndexVM.PageNumber == 0 ? 1 : ReservationIndexVM.PageNumber;
            var query = _mapper.Map<ReservationIndexViewModel>(await _reservationRepository.GetReservationList(ReservationIndexVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(ReservationIndexVM.SearchString))
                query.SearchString = ReservationIndexVM.SearchString;

            return query;
        }

        public async Task<ReservationIndexViewModel> GetReservationList(ReservationDeleteViewModel ReservationDeleteVM, int pageSize)
        {
            var pageNumber = ReservationDeleteVM.PageNumber == 0 ? 1 : ReservationDeleteVM.PageNumber;
            var query = _mapper.Map<ReservationIndexViewModel>(await _reservationRepository.GetReservationList(ReservationDeleteVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(ReservationDeleteVM.SearchString))
                query.SearchString = ReservationDeleteVM.SearchString;

            return query;
        }

        public async Task AddReservation(ReservationViewModel reservationVM)
        {
            var Reservation = _mapper.Map<Reservation>(reservationVM);
            await _reservationRepository.AddReservation(Reservation);
        }

        public async Task UpdateReservation(ReservationViewModel ReservationVM)
        {
            var entity = await _reservationRepository.GetReservation(ReservationVM.Id);

            var Reservation = _mapper.Map(ReservationVM, entity);

            await _reservationRepository.UpdateReservation(Reservation);
        }

        public async Task RemoveReservation(Guid id)
        {
            await _reservationRepository.RemoveReservation(id);
        }

        public bool GetReservationExists(Guid id)
        {
            return _reservationRepository.GetReservationExists(id);
        }
    }
}
