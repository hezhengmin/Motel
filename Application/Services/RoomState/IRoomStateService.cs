using Application.ViewModels.RoomState;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IRoomStateService
    {
        Task<RoomStateViewModel> GetRoomState(Guid id);
        Task AddRoomState(RoomStateViewModel RoomStateVM);
        Task UpdateRoomState(RoomStateViewModel RoomStateVM);
        Task RemoveRoomState(Guid id);
    }
}
