using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Room
{
    public class CompoundViewModel
    {
        public RoomViewModel CustomerViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
