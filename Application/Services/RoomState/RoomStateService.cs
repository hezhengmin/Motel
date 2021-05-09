using Application.Repository;
using Application.ViewModels.RoomState;
using AutoMapper;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoomStateService : IRoomStateService
    {
        private readonly IMapper _mapper;
        private readonly IRoomStateRepository _roomStateRepository;

        public RoomStateService(IMapper mapper,
                                IRoomStateRepository RoomStateRepository)
        {
            _mapper = mapper;
            _roomStateRepository = RoomStateRepository;
        }

        public async Task<RoomStateViewModel> GetRoomState(Guid id)
        {
            return _mapper.Map<RoomStateViewModel>(await _roomStateRepository.GetRoomState(id));
        }
       
        public async Task AddRoomState(RoomStateViewModel roomStateVM)
        {
            var roomState = _mapper.Map<RoomState>(roomStateVM);
            await _roomStateRepository.AddRoomState(roomState);
        }

        public async Task UpdateRoomState(RoomStateViewModel roomStateVM)
        {
            var entity = await _roomStateRepository.GetRoomState(roomStateVM.Id);

            var RoomState = _mapper.Map(roomStateVM, entity);

            await _roomStateRepository.UpdateRoomState(RoomState);
        }

        public async Task RemoveRoomState(Guid id)
        {
            await _roomStateRepository.RemoveRoomState(id);
        }
    }
}
