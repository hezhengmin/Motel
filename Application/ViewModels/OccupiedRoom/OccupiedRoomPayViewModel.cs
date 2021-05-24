using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.OccupiedRoom
{
    public class OccupiedRoomPayViewModel
    {
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public Guid? RoomTypeId { get; set; }
    }
}
