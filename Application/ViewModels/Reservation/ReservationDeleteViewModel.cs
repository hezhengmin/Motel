using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Reservation
{
    public class ReservationDeleteViewModel
    {
        public Guid Id { get; set; }
        public int PageNumber { get; set; }
        public string SearchString { get; set; }
    }
}
