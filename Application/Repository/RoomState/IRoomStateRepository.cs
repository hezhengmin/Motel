using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IRoomStateRepository
    {
        Task<RoomState> GetRoomState(Guid id);
        Task AddRoomState(RoomState RoomState);
        Task UpdateRoomState(RoomState RoomState);
        Task RemoveRoomState(Guid id);
    }
}
