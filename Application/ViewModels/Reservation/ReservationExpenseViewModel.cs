using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Reservation
{
    public class ReservationExpenseViewModel
    {
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? RoomTypeId { get; set; }
    }
}
