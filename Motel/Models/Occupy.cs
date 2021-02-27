using System;
using System.Collections.Generic;

#nullable disable

namespace Motel.Models
{
    public partial class Occupy
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
        public virtual GuestRoom GusetRoom { get; set; }
    }
}
