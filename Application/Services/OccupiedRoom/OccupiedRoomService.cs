using Application.Repository;
using Application.ViewModels.OccupiedRoom;
using AutoMapper;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Application.Services
{
    public class OccupiedRoomService : IOccupiedRoomService
    {
        private readonly IMapper _mapper;
        private readonly IOccupiedRoomRepository _occupiedRoomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public OccupiedRoomService(IMapper mapper,
                                   IRoomTypeRepository roomTypeRepository,
                                   IOccupiedRoomRepository occupiedRoomRepository)
        {
            _mapper = mapper;
            _roomTypeRepository = roomTypeRepository;
            _occupiedRoomRepository = occupiedRoomRepository;
        }

        public async Task<OccupiedRoomViewModel> GetOccupiedRoom(Guid id)
        {
            return _mapper.Map<OccupiedRoomViewModel>(await _occupiedRoomRepository.GetOccupiedRoom(id));
        }

        public async Task<OccupiedRoomDetailViewModel> GetOccupiedRoomDetail(Guid id)
        {
            return _mapper.Map<OccupiedRoomDetailViewModel>(await _occupiedRoomRepository.GetOccupiedRoomDetailDTO(id));
        }

        public async Task<CompoundOccupiedRoomViewModel> GetAddOrEditOccupiedRoomDetail(Guid id)
        {
            var model = new CompoundOccupiedRoomViewModel();

            model.OccupiedRoomDetailViewModel = await this.GetOccupiedRoomDetail(id);

            return model;
        }

        public async Task<OccupiedRoomIndexViewModel> GetOccupiedRoomList(int pageNumber, int pageSize)
        {
            return _mapper.Map<OccupiedRoomIndexViewModel>(await _occupiedRoomRepository.GetOccupiedRoomList(pageNumber, pageSize));
        }

        public async Task<OccupiedRoomIndexViewModel> GetOccupiedRoomList(OccupiedRoomIndexViewModel occupiedRoomIndexVM, int pageSize)
        {
            var pageNumber = occupiedRoomIndexVM.PageNumber == 0 ? 1 : occupiedRoomIndexVM.PageNumber;
            var query = _mapper.Map<OccupiedRoomIndexViewModel>(await _occupiedRoomRepository.GetOccupiedRoomList(occupiedRoomIndexVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(occupiedRoomIndexVM.SearchString))
                query.SearchString = occupiedRoomIndexVM.SearchString;

            return query;
        }

        public async Task<OccupiedRoomIndexViewModel> GetOccupiedRoomList(FilterViewModel filterVM, int pageSize)
        {
            var pageNumber = filterVM.PageNumber == 0 ? 1 : filterVM.PageNumber;
            var query = _mapper.Map<OccupiedRoomIndexViewModel>(await _occupiedRoomRepository.GetOccupiedRoomList(filterVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(filterVM.SearchString))
                query.SearchString = filterVM.SearchString;

            return query;
        }
        public async Task<OccupiedRoomViewModel> GetOccupiedRoomPay(OccupiedRoomPayViewModel payVM)
        {
            OccupiedRoomViewModel occupiedRoomVM = new OccupiedRoomViewModel();
            occupiedRoomVM.Pay = 0;

            if (!payVM.RoomTypeId.HasValue ||
                !payVM.CheckInDate.HasValue ||
                !payVM.CheckOutDate.HasValue)
                return occupiedRoomVM;

            DateTime checkInDate = payVM.CheckInDate.Value;
            DateTime checkOutDate = payVM.CheckOutDate.Value;

            var comparison = checkOutDate.CompareTo(checkInDate);
            if (comparison < 0) return occupiedRoomVM;

            var roomType = await _roomTypeRepository.GetRoomType(payVM.RoomTypeId.Value);

            var pay = 0;
            foreach (var day in MyDateHelper.EachDay(checkInDate, checkOutDate))
            {
                if (day.DayOfWeek == DayOfWeek.Saturday) pay += roomType.Hprice;
                else if (day.DayOfWeek == DayOfWeek.Sunday) pay += roomType.Hprice;
                else pay += roomType.Price;
            }

            occupiedRoomVM.Pay = pay;

            return occupiedRoomVM;
        }
        public async Task AddOccupiedRoom(OccupiedRoomViewModel occupiedRoomVM)
        {
            var occupiedRoom = _mapper.Map<OccupiedRoom>(occupiedRoomVM);
            await _occupiedRoomRepository.AddOccupiedRoom(occupiedRoom);
        }
        public async Task UpdateOccupiedRoom(OccupiedRoomDetailViewModel occupiedRoomDetailVM)
        {
            var entity = await _occupiedRoomRepository.GetOccupiedRoom(occupiedRoomDetailVM.Id);

            var occupiedRoom = _mapper.Map(occupiedRoomDetailVM, entity);

            await _occupiedRoomRepository.UpdateOccupiedRoom(occupiedRoom);
        }
        public async Task UpdateOccupiedRoom(OccupiedRoomViewModel occupiedRoomVM)
        {
            var entity = await _occupiedRoomRepository.GetOccupiedRoom(occupiedRoomVM.Id);

            var occupiedRoom = _mapper.Map(occupiedRoomVM, entity);

            await _occupiedRoomRepository.UpdateOccupiedRoom(occupiedRoom);
        }
        public async Task RemoveOccupiedRoom(Guid id)
        {
            await _occupiedRoomRepository.RemoveOccupiedRoom(id);
        }
    }
}