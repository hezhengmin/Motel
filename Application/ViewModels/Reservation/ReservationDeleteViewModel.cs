using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Reservation
{
    public class ReservationDeleteViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int PageNumber { get; set; }
        public string ReservationSearchString { get; set; }
    }
}
