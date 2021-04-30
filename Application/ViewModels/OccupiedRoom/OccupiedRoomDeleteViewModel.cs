using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.OccupiedRoom
{
    public class OccupiedRoomDeleteViewModel
    {
        public Guid Id { get; set; }
        public int PageNumber { get; set; }
        public string SearchString { get; set; }
    }
}
