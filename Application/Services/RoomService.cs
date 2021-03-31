using AutoMapper;
using Application.ViewModels.Room;
using Application.Repository;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _RoomRepository;

        public RoomService(IMapper mapper, IRoomRepository RoomRepository)
        {
            _mapper = mapper;
            _RoomRepository = RoomRepository;
        }

        public async Task<RoomViewModel> GetRoom(Guid id)
        {
            return _mapper.Map<RoomViewModel>(await _RoomRepository.GetRoom(id));
        }

        public async Task<List<RoomViewModel>> GetRoomList()
        {
            return _mapper.Map<List<RoomViewModel>>(await _RoomRepository.GetRoomList());
        }

        public async Task<RoomIndexViewModel> GetRoomList(int pageNumber, int pageSize)
        {
            var query = _mapper.Map<RoomIndexViewModel>(await _RoomRepository.GetRoomList(pageNumber, pageSize));
            return query;
        }

        public async Task<RoomIndexViewModel> GetRoomList(FilterViewModel filterVM, int pageSize)
        {
            var pageNumber = filterVM.PageNumber == 0 ? 1 : filterVM.PageNumber;
            var query = _mapper.Map<RoomIndexViewModel>(await _RoomRepository.GetRoomList(filterVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(filterVM.SearchString))
                query.SearchString = filterVM.SearchString;

            return query;
        }

        public async Task<RoomIndexViewModel> GetRoomList(RoomIndexViewModel RoomIndexVM, int pageSize)
        {
            var pageNumber = RoomIndexVM.PageNumber == 0 ? 1 : RoomIndexVM.PageNumber;
            var query = _mapper.Map<RoomIndexViewModel>(await _RoomRepository.GetRoomList(RoomIndexVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(RoomIndexVM.SearchString))
                query.SearchString = RoomIndexVM.SearchString;

            return query;
        }

        public async Task<RoomIndexViewModel> GetRoomList(RoomDeleteViewModel RoomDeleteVM, int pageSize)
        {
            var pageNumber = RoomDeleteVM.PageNumber == 0 ? 1 : RoomDeleteVM.PageNumber;
            var query = _mapper.Map<RoomIndexViewModel>(await _RoomRepository.GetRoomList(RoomDeleteVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(RoomDeleteVM.SearchString))
                query.SearchString = RoomDeleteVM.SearchString;

            return query;
        }

        public async Task AddRoom(RoomViewModel RoomVM)
        {
            var Room = _mapper.Map<Room>(RoomVM);
            await _RoomRepository.AddRoom(Room);
        }

        public async Task UpdateRoom(RoomViewModel RoomVM)
        {
            var entity = await _RoomRepository.GetRoom(RoomVM.Id);

            var Room = _mapper.Map(RoomVM, entity);

            await _RoomRepository.UpdateRoom(Room);
        }

        public async Task RemoveRoom(Guid id)
        {
            await _RoomRepository.RemoveRoom(id);
        }

        public bool GetRoomExists(Guid id)
        {
            return _RoomRepository.GetRoomExists(id);
        }
    }
}
