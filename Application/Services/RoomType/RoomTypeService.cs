using AutoMapper;
using Application.ViewModels.RoomType;
using Application.Repository;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IMapper _mapper;
        private readonly IRoomTypeRepository _RoomTypeRepository;

        public RoomTypeService(IMapper mapper, IRoomTypeRepository roomTypeRepository)
        {
            _mapper = mapper;
            _RoomTypeRepository = roomTypeRepository;
        }

        public async Task<RoomTypeViewModel> GetRoomType(Guid id)
        {
            return _mapper.Map<RoomTypeViewModel>(await _RoomTypeRepository.GetRoomType(id));
        }

        public async Task<List<RoomTypeViewModel>> GetRoomTypeList()
        {
            return _mapper.Map<List<RoomTypeViewModel>>(await _RoomTypeRepository.GetRoomTypeList());
        }

        public async Task<RoomTypeIndexViewModel> GetRoomTypeList(int pageNumber, int pageSize)
        {
            var query = _mapper.Map<RoomTypeIndexViewModel>(await _RoomTypeRepository.GetRoomTypeList(pageNumber, pageSize));
            return query;
        }

        public async Task<RoomTypeIndexViewModel> GetRoomTypeList(FilterViewModel filterVM, int pageSize)
        {
            var pageNumber = filterVM.PageNumber == 0 ? 1 : filterVM.PageNumber;
            var query = _mapper.Map<RoomTypeIndexViewModel>(await _RoomTypeRepository.GetRoomTypeList(filterVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(filterVM.SearchString))
                query.SearchString = filterVM.SearchString;

            return query;
        }

        public async Task<RoomTypeIndexViewModel> GetRoomTypeList(RoomTypeIndexViewModel RoomTypeIndexVM, int pageSize)
        {
            var pageNumber = RoomTypeIndexVM.PageNumber == 0 ? 1 : RoomTypeIndexVM.PageNumber;
            var query = _mapper.Map<RoomTypeIndexViewModel>(await _RoomTypeRepository.GetRoomTypeList(RoomTypeIndexVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(RoomTypeIndexVM.SearchString))
                query.SearchString = RoomTypeIndexVM.SearchString;

            return query;
        }

        public async Task<RoomTypeIndexViewModel> GetRoomTypeList(RoomTypeDeleteViewModel RoomTypeDeleteVM, int pageSize)
        {
            var pageNumber = RoomTypeDeleteVM.PageNumber == 0 ? 1 : RoomTypeDeleteVM.PageNumber;
            var query = _mapper.Map<RoomTypeIndexViewModel>(await _RoomTypeRepository.GetRoomTypeList(RoomTypeDeleteVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(RoomTypeDeleteVM.SearchString))
                query.SearchString = RoomTypeDeleteVM.SearchString;

            return query;
        }

        public async Task AddRoomType(RoomTypeViewModel RoomTypeVM)
        {
            var RoomType = _mapper.Map<RoomType>(RoomTypeVM);
            await _RoomTypeRepository.AddRoomType(RoomType);
        }

        public async Task UpdateRoomType(RoomTypeViewModel RoomTypeVM)
        {
            var entity = await _RoomTypeRepository.GetRoomType(RoomTypeVM.Id);

            var RoomType = _mapper.Map(RoomTypeVM, entity);

            await _RoomTypeRepository.UpdateRoomType(RoomType);
        }

        public async Task RemoveRoomType(Guid id)
        {
            await _RoomTypeRepository.RemoveRoomType(id);
        }

        public bool GetRoomTypeExists(Guid id)
        {
            return _RoomTypeRepository.GetRoomTypeExists(id);
        }
    }
}
