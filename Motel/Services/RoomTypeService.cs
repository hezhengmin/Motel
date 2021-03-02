using AutoMapper;
using Motel.Models;
using Motel.Repository;
using Motel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Services
{
    public class RoomTypeService :IRoomTypeService
    {
        private readonly IMapper _mapper;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService(IMapper mapper, IRoomTypeRepository roomTypeRepository)
        {
            _mapper = mapper;
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<RoomTypeViewModel> GetRoomType(Guid id)
        {
            return _mapper.Map<RoomTypeViewModel>(await _roomTypeRepository.GetRoomType(id));
        }

        public async Task<List<RoomTypeViewModel>> GetRoomTypeList()
        {
            return _mapper.Map<List<RoomTypeViewModel>>(await _roomTypeRepository.GetRoomTypeList());
        }

        public async Task AddRoomType(RoomTypeViewModel roomTypeVM)
        {
            var roomType = _mapper.Map<RoomType>(roomTypeVM);
            await _roomTypeRepository.AddRoomType(roomType);
        }
        public async Task UpdateRoomType(RoomTypeViewModel roomTypeVM)
        {
            var roomType = _mapper.Map<RoomType>(roomTypeVM);
            await _roomTypeRepository.UpdateRoomType(roomType);
        }

        public async Task RemoveRoomType(Guid id)
        {
            await _roomTypeRepository.RemoveRoomType(id);
        }

        public bool GetRoomTypeExists(Guid id)
        {
            return _roomTypeRepository.GetRoomTypeExists(id);
        }
    }
}
