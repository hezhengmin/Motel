using AutoMapper;
using Application.ViewModels.Room;
using Application.Repository;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomService(IMapper mapper,
                           IRoomRepository roomRepository,
                           IRoomTypeRepository roomTypeRepository)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<RoomViewModel> GetRoom(Guid id)
        {
            return _mapper.Map<RoomViewModel>(await _roomRepository.GetRoom(id));
        }

        public async Task<CompoundViewModel> GetAddOrEditRoom(Guid? id)
        {
            var model = new CompoundViewModel();
            if (id == null || id == Guid.Empty)
            {
                model.RoomViewModel = new RoomViewModel();
            }
            else
            {
                var roomVM = await this.GetRoom(id.Value);
                model.RoomViewModel = roomVM;
            }

            model.RoomViewModel.RoomTypeList = new List<SelectListItem>();

            foreach (var roomType in _roomTypeRepository.GetRoomTypeList().Result)
            {
                model.RoomViewModel.RoomTypeList.Add(new SelectListItem(roomType.Name, roomType.Id.ToString()));
            }

            return model;
        }

        public async Task<List<RoomViewModel>> GetRoomList()
        {
            return _mapper.Map<List<RoomViewModel>>(await _roomRepository.GetRoomList());
        }

        public async Task<RoomIndexViewModel> GetRoomList(int pageNumber, int pageSize)
        {
            var query = _mapper.Map<RoomIndexViewModel>(await _roomRepository.GetRoomList(pageNumber, pageSize));
            return query;
        }

        public async Task<RoomIndexViewModel> GetRoomList(FilterViewModel filterVM, int pageSize)
        {
            var pageNumber = filterVM.PageNumber == 0 ? 1 : filterVM.PageNumber;
            var query = _mapper.Map<RoomIndexViewModel>(await _roomRepository.GetRoomList(filterVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(filterVM.SearchString))
                query.SearchString = filterVM.SearchString;

            return query;
        }

        public async Task<RoomIndexViewModel> GetRoomList(RoomIndexViewModel RoomIndexVM, int pageSize)
        {
            var pageNumber = RoomIndexVM.PageNumber == 0 ? 1 : RoomIndexVM.PageNumber;
            var query = _mapper.Map<RoomIndexViewModel>(await _roomRepository.GetRoomList(RoomIndexVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(RoomIndexVM.SearchString))
                query.SearchString = RoomIndexVM.SearchString;

            return query;
        }

        public async Task<RoomIndexViewModel> GetRoomList(RoomDeleteViewModel RoomDeleteVM, int pageSize)
        {
            var pageNumber = RoomDeleteVM.PageNumber == 0 ? 1 : RoomDeleteVM.PageNumber;
            var query = _mapper.Map<RoomIndexViewModel>(await _roomRepository.GetRoomList(RoomDeleteVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(RoomDeleteVM.SearchString))
                query.SearchString = RoomDeleteVM.SearchString;

            return query;
        }

        public async Task AddRoom(RoomViewModel RoomVM)
        {
            var Room = _mapper.Map<Room>(RoomVM);
            await _roomRepository.AddRoom(Room);
        }

        public async Task UpdateRoom(RoomViewModel RoomVM)
        {
            var entity = await _roomRepository.GetRoom(RoomVM.Id);

            var Room = _mapper.Map(RoomVM, entity);

            await _roomRepository.UpdateRoom(Room);
        }

        public async Task RemoveRoom(Guid id)
        {
            await _roomRepository.RemoveRoom(id);
        }

        public bool GetRoomExists(Guid id)
        {
            return _roomRepository.GetRoomExists(id);
        }


    }
}
