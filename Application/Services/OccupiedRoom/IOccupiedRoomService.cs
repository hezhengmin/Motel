﻿using Application.ViewModels.OccupiedRoom;
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
        Task AddOccupiedRoom(OccupiedRoomViewModel occupiedRoomVM);
        Task UpdateOccupiedRoom(OccupiedRoomViewModel occupiedRoomVM);
        Task RemoveOccupiedRoom(Guid id);
    }
}
