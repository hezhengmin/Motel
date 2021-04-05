using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Reservation
{
    public class CompoundViewModel
    {
        public ReservationViewModel ReservationViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
