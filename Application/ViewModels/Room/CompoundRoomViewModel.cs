using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Room
{
    public class CompoundRoomViewModel
    {
        public RoomViewModel RoomViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
