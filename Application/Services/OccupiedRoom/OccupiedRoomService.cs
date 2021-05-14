using Application.Repository;
using Application.ViewModels.OccupiedRoom;
using AutoMapper;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OccupiedRoomService : IOccupiedRoomService
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IOccupiedRoomRepository _occupiedRoomRepository;

        public OccupiedRoomService(IMapper mapper,
                                  IReservationRepository reservationRepository,
                                  IRoomRepository roomRepository,
                                  IRoomTypeRepository roomTypeRepository,
                                  IOccupiedRoomRepository occupiedRoomRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;
            _occupiedRoomRepository = occupiedRoomRepository;
        }

        public async Task<OccupiedRoomViewModel> GetOccupiedRoom(Guid id)
        {
            return _mapper.Map<OccupiedRoomViewModel>(await _occupiedRoomRepository.GetOccupiedRoom(id));
        }

        public async Task<OccupiedRoomDetailViewModel> GetOccupiedRoomDetail(Guid id)
        {
            return _mapper.Map<OccupiedRoomDetailViewModel>(await _reservationRepository.GetReservationDetailDTO(id));
        }

        public async Task<CompoundOccupiedRoomViewModel> GetAddOrEditOccupiedRoomDetail(Guid id)
        {
            var model = new CompoundOccupiedRoomViewModel();

            model.OccupiedRoomDetailViewModel = await this.GetOccupiedRoomDetail(id);

            return model;
        }

        public async Task AddOccupiedRoom(OccupiedRoomViewModel occupiedRoomVM)
        {
            var occupiedRoom = _mapper.Map<OccupiedRoom>(occupiedRoomVM);
            await _occupiedRoomRepository.AddOccupiedRoom(occupiedRoom);
        }

        public async Task UpdateOccupiedRoom(OccupiedRoomViewModel occupiedRoomVM)
        {
            var entity = await _occupiedRoomRepository.GetOccupiedRoom(occupiedRoomVM.Id);

            var OccupiedRoom = _mapper.Map(occupiedRoomVM, entity);

            await _occupiedRoomRepository.UpdateOccupiedRoom(OccupiedRoom);
        }

        public async Task RemoveOccupiedRoom(Guid id)
        {
            await _occupiedRoomRepository.RemoveOccupiedRoom(id);
        }
    }
}
