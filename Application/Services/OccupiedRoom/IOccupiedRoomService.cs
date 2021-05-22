using Application.ViewModels.OccupiedRoom;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IOccupiedRoomService
    {
        Task<OccupiedRoomViewModel> GetOccupiedRoom(Guid id);
        Task<OccupiedRoomDetailViewModel> GetOccupiedRoomDetail(Guid id);
        Task<CompoundOccupiedRoomViewModel> GetAddOrEditOccupiedRoomDetail(Guid id);
        Task<OccupiedRoomIndexViewModel> GetOccupiedRoomList(int pageNumber, int pageSize);
        Task<OccupiedRoomIndexViewModel> GetOccupiedRoomList(OccupiedRoomIndexViewModel occupiedRoomIndexVM, int pageSize);
        Task<OccupiedRoomIndexViewModel> GetOccupiedRoomList(FilterViewModel filterVM, int pageSize);
        Task AddOccupiedRoom(OccupiedRoomViewModel occupiedRoomVM);
        Task UpdateOccupiedRoom(OccupiedRoomViewModel occupiedRoomVM);
        Task UpdateOccupiedRoom(OccupiedRoomDetailViewModel occupiedRoomDetailVM);
        Task RemoveOccupiedRoom(Guid id);
    }
}
