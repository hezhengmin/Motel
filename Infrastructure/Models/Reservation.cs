using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Infrastructure.Models
{
    public partial class Reservation
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Days { get; set; }
        public int Expense { get; set; }
        public DateTime SysDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
    }
}
