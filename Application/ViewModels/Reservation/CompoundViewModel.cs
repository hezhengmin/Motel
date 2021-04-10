using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Reservation
{
    public class CompoundReservationViewModel
    {
        public ReservationViewModel ReservationViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
