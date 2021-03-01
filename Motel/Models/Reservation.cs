using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Motel.Models
{
    public partial class Reservation
    {
        public Guid Id { get; set; }
        public Guid RoomTypeId { get; set; }
        public DateTime BeginDate { get; set; }
        public byte Days { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public bool CheckIn { get; set; }
        public string RoomNumber { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}
