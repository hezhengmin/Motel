using Application.Repository;
using Infrastructure.Models;
using Application.ViewModels.Reservation;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Util;

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
            return _mapper.Map<ReservationViewModel>(await _reservationRepository.GetMultipleEntitiesReservation(id));
        }

        public async Task<CompoundReservationViewModel> GetAddOrEditReservation(Guid? id, Guid customerId)
        {
            var model = new CompoundReservationViewModel();
            if (id == null || id == Guid.Empty)
            {
                model.ReservationViewModel = new ReservationViewModel
                {
                    CustomerId = customerId,
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Days = 1,
                    Expense = 0,
                };
            }
            else
            {
                var roomVM = await this.GetReservation(id.Value);
                model.ReservationViewModel = roomVM;
            }

            //房間類型
            model.ReservationViewModel.RoomTypeList = new List<SelectListItem>();
            model.ReservationViewModel.RoomTypeList.Add(new SelectListItem("請選擇", ""));

            foreach (var roomType in await _roomTypeRepository.GetRoomTypeList())
            {
                model.ReservationViewModel.RoomTypeList.Add(new SelectListItem(roomType.Name, roomType.Id.ToString()));
            }


            //房間號碼
            model.ReservationViewModel.RoomList = new List<SelectListItem>();
            model.ReservationViewModel.RoomList.Add(new SelectListItem("請選擇", ""));

            if (model.ReservationViewModel.RoomTypeId != null)
            {
                foreach (var room in await _roomRepository.GetRoomList(model.ReservationViewModel.RoomTypeId))
                {
                    model.ReservationViewModel.RoomList.Add(new SelectListItem(room.RoomNumber, room.Id.ToString()));
                }
            }

            return model;
        }

        public async Task<CompoundReservationViewModel> GetAddOrEditReservation(CompoundReservationViewModel compoundVM)
        {
            //房間類型
            compoundVM.ReservationViewModel.RoomTypeList = new List<SelectListItem>();
            compoundVM.ReservationViewModel.RoomTypeList.Add(new SelectListItem("請選擇", ""));

            foreach (var roomType in await _roomTypeRepository.GetRoomTypeList())
            {
                compoundVM.ReservationViewModel.RoomTypeList.Add(new SelectListItem(roomType.Name, roomType.Id.ToString()));
            }

            //房間號碼
            compoundVM.ReservationViewModel.RoomList = new List<SelectListItem>();
            compoundVM.ReservationViewModel.RoomList.Add(new SelectListItem("請選擇", ""));

            if (compoundVM.ReservationViewModel.RoomTypeId.HasValue)
            {
                foreach (var room in await _roomRepository.GetRoomList(compoundVM.ReservationViewModel.RoomTypeId.Value))
                {
                    compoundVM.ReservationViewModel.RoomList.Add(new SelectListItem(room.RoomNumber, room.Id.ToString()));
                }
            }

            return compoundVM;
        }

        public async Task<List<ReservationViewModel>> GetReservationList()
        {
            return _mapper.Map<List<ReservationViewModel>>(await _reservationRepository.GetReservationList());
        }

        public async Task<ReservationIndexViewModel> GetReservationList(int pageNumber, int pageSize)
        {
            return _mapper.Map<ReservationIndexViewModel>(await _reservationRepository.GetReservationList(pageNumber, pageSize));
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

        //public async Task<ReservationIndexViewModel> GetReservationList(ReservationSearchField searchField, ReservationIndexViewModel reservationIndexVM, int pageSize)
        //{
        //    var pageNumber = reservationIndexVM.PageNumber == 0 ? 1 : reservationIndexVM.PageNumber;
        //    var query = _mapper.Map<ReservationIndexViewModel>(await _reservationRepository.GetReservationList(searchField, reservationIndexVM.ReservationSearchString, pageNumber, pageSize));

        //    if (!string.IsNullOrEmpty(reservationIndexVM.ReservationSearchString))
        //        query.ReservationSearchString = reservationIndexVM.ReservationSearchString;
        //    if (reservationIndexVM.CustomerId != null)
        //        query.CustomerId = reservationIndexVM.CustomerId;

        //    return query;
        //}

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

        public async Task<ReservationViewModel> GetReservationExpense(ReservationExpenseViewModel expenseVM)
        {
            ReservationViewModel reservationVM = new ReservationViewModel();
            reservationVM.Expense = 0;
            reservationVM.Days = 0;

            if (!expenseVM.RoomTypeId.HasValue ||
                !expenseVM.BeginDate.HasValue ||
                !expenseVM.EndDate.HasValue)
                return reservationVM;

            DateTime beginDate = expenseVM.BeginDate.Value;
            DateTime endDate = expenseVM.EndDate.Value;

            var comparison = endDate.CompareTo(beginDate);
            if (comparison < 0) return reservationVM;

            var roomType = await _roomTypeRepository.GetRoomType(expenseVM.RoomTypeId.Value);

            var expense = 0;
            foreach (var day in MyDateHelper.EachDay(beginDate, endDate))
            {
                if (day.DayOfWeek == DayOfWeek.Saturday) expense += roomType.Hprice;
                else if (day.DayOfWeek == DayOfWeek.Sunday) expense += roomType.Hprice;
                else expense += roomType.Price;
            }

            TimeSpan interval = endDate - beginDate;

            reservationVM.Expense = expense;
            reservationVM.Days = interval.Days + 1;

            return reservationVM;
        }

        public async Task<bool> GetReservationDateIsOverlapAsync(ReservationViewModel reservationVM)
        {

            Guid roomId = reservationVM.RoomId.Value;
            DateTime beginDate = reservationVM.BeginDate.Value;
            DateTime endDate = reservationVM.EndDate.Value;

            bool isOverlap = false;

            if (reservationVM.Id == null || reservationVM.Id == Guid.Empty)
            {
                isOverlap = await _reservationRepository.GetReservationDateIsOverlap(roomId, beginDate, endDate);
            }
            else
            {
                isOverlap = await _reservationRepository.GetReservationDateIsOverlap(reservationVM.Id, roomId, beginDate, endDate);
            }

            return isOverlap;
        }


        public async Task AddReservation(ReservationViewModel reservationVM)
        {
            var Reservation = _mapper.Map<Reservation>(reservationVM);
            await _reservationRepository.AddReservation(Reservation);
        }

        public async Task UpdateReservation(ReservationViewModel ReservationVM)
        {
            var entity = await _reservationRepository.GetReservationWithOccupied(ReservationVM.Id);

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
