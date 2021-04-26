using Application.Repository;
using Infrastructure.Models;
using Application.ViewModels.Reservation;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public ReservationService(IMapper mapper,
                                  IReservationRepository reservationRepository,
                                  IRoomRepository roomRepository,
                                  IRoomTypeRepository roomTypeRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<ReservationViewModel> GetReservation(Guid id)
        {
            return _mapper.Map<ReservationViewModel>(await _reservationRepository.GetReservation(id));
        }

        public async Task<CompoundReservationViewModel> GetAddOrEditReservation(Guid? id, Guid customerId)
        {
            var model = new CompoundReservationViewModel();
            if (id == null || id == Guid.Empty)
            {
                model.ReservationViewModel = new ReservationViewModel
                {
                    Days = 1,
                    CustomerId = customerId,
                    BeginDate = DateTime.Now
                };
            }
            else
            {
                var roomVM = await this.GetReservation(id.Value);
                model.ReservationViewModel = roomVM;
            }

            //房間資料

            model.ReservationViewModel.RoomList = new List<SelectListItem>();
            model.ReservationViewModel.RoomList.Add(new SelectListItem("請選擇", ""));

            //foreach (var room in _roomRepository.GetRoomList().Result)
            //{
            //    model.ReservationViewModel.RoomList.Add(new SelectListItem(room.RoomNumber, room.Id.ToString()));
            //}

            //房間類型

            model.ReservationViewModel.RoomTypeList = new List<SelectListItem>();
            model.ReservationViewModel.RoomTypeList.Add(new SelectListItem("請選擇", ""));

            foreach (var roomType in await _roomTypeRepository.GetRoomTypeList())
            {
                model.ReservationViewModel.RoomTypeList.Add(new SelectListItem(roomType.Name, roomType.Id.ToString()));
            }

            return model;
        }

        public async Task<CompoundReservationViewModel> GetAddOrEditReservation(CompoundReservationViewModel compoundVM)
        {

            compoundVM.ReservationViewModel.RoomList = new List<SelectListItem>();
            compoundVM.ReservationViewModel.RoomList.Add(new SelectListItem("請選擇", ""));

            //foreach (var room in await _roomRepository.GetRoomList())
            //{
            //    compoundVM.ReservationViewModel.RoomList.Add(new SelectListItem(room.RoomNumber, room.Id.ToString()));
            //}

            compoundVM.ReservationViewModel.RoomTypeList = new List<SelectListItem>();
            compoundVM.ReservationViewModel.RoomTypeList.Add(new SelectListItem("請選擇", ""));
            
            foreach (var roomType in await _roomTypeRepository.GetRoomTypeList())
            {
                compoundVM.ReservationViewModel.RoomTypeList.Add(new SelectListItem(roomType.Name, roomType.Id.ToString()));
            }

            return compoundVM;
        }

        public async Task<List<ReservationViewModel>> GetReservationList()
        {
            return _mapper.Map<List<ReservationViewModel>>(await _reservationRepository.GetReservationList());
        }

        public async Task<ReservationIndexViewModel> GetReservationList(Guid customerId, int pageNumber, int pageSize)
        {
            var query = _mapper.Map<ReservationIndexViewModel>(await _reservationRepository.GetReservationList(customerId, pageNumber, pageSize));
            query.CustomerId = customerId;

            return query;
        }

        public async Task<ReservationIndexViewModel> GetReservationList(Guid customerId, FilterViewModel filterVM, int pageSize)
        {
            var pageNumber = filterVM.PageNumber == 0 ? 1 : filterVM.PageNumber;
            var query = _mapper.Map<ReservationIndexViewModel>(await _reservationRepository.GetReservationList(customerId, filterVM.SearchString, pageNumber, pageSize));
            query.CustomerId = customerId;

            if (!string.IsNullOrEmpty(filterVM.SearchString))
                query.ReservationSearchString = filterVM.SearchString;

            return query;
        }

        public async Task<ReservationIndexViewModel> GetReservationList(CompoundReservationViewModel compoundVM, int pageSize)
        {
            if (compoundVM.ReservationViewModel.Id == null || compoundVM.ReservationViewModel.Id == Guid.Empty)
            {
                await this.AddReservation(compoundVM.ReservationViewModel);
                var model = await this.GetReservationList(compoundVM.ReservationViewModel.CustomerId, 1, pageSize);
                return model;
            }
            else
            {
                await this.UpdateReservation(compoundVM.ReservationViewModel);
                var model = await this.GetReservationList(compoundVM.ReservationViewModel.CustomerId, compoundVM.FilterViewModel, pageSize);
                return model;
            }
        }

        public async Task<ReservationIndexViewModel> GetReservationList(Guid customerId, ReservationIndexViewModel ReservationIndexVM, int pageSize)
        {
            var pageNumber = ReservationIndexVM.PageNumber == 0 ? 1 : ReservationIndexVM.PageNumber;
            var query = _mapper.Map<ReservationIndexViewModel>(await _reservationRepository.GetReservationList(ReservationIndexVM.ReservationSearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(ReservationIndexVM.ReservationSearchString))
                query.ReservationSearchString = ReservationIndexVM.ReservationSearchString;

            return query;
        }

        public async Task<ReservationIndexViewModel> GetReservationList(ReservationIndexViewModel ReservationIndexVM, int pageSize)
        {
            var pageNumber = ReservationIndexVM.PageNumber == 0 ? 1 : ReservationIndexVM.PageNumber;
            var query = _mapper.Map<ReservationIndexViewModel>(await _reservationRepository.GetReservationList(ReservationIndexVM.CustomerId, ReservationIndexVM.ReservationSearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(ReservationIndexVM.ReservationSearchString))
                query.ReservationSearchString = ReservationIndexVM.ReservationSearchString;
            if (ReservationIndexVM.CustomerId != null)
                query.CustomerId = ReservationIndexVM.CustomerId;

            return query;
        }

        public async Task<ReservationIndexViewModel> GetReservationList(ReservationDeleteViewModel ReservationDeleteVM, int pageSize)
        {
            var pageNumber = ReservationDeleteVM.PageNumber == 0 ? 1 : ReservationDeleteVM.PageNumber;
            var query = _mapper.Map<ReservationIndexViewModel>(await _reservationRepository.GetReservationList(ReservationDeleteVM.CustomerId, ReservationDeleteVM.ReservationSearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(ReservationDeleteVM.ReservationSearchString))
                query.ReservationSearchString = ReservationDeleteVM.ReservationSearchString;
            if (ReservationDeleteVM.CustomerId != null)
                query.CustomerId = ReservationDeleteVM.CustomerId;

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
