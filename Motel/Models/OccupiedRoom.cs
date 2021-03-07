using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Motel.Models
{
    public partial class OccupiedRoom
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid GusetRoomId { get; set; }
        public string Number { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public decimal? Pay { get; set; }
        public decimal? PrePay { get; set; }
        public decimal? Price { get; set; }
        public int? Days { get; set; }
        public bool OccupyType { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Room GusetRoom { get; set; }
    }
}
