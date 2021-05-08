using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Infrastructure.Models
{
    public partial class OccupiedRoom
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? Pay { get; set; }
        public int? Days { get; set; }
        public bool Balance { get; set; }
        public DateTime SysDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual Room Room { get; set; }
    }
}
