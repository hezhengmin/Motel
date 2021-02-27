using System;
using System.Collections.Generic;

#nullable disable

namespace Motel.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            GuestRooms = new HashSet<GuestRoom>();
            Reservations = new HashSet<Reservation>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public int BedQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal Hprice { get; set; }
        public decimal Qkprice { get; set; }
        public decimal Qk2price { get; set; }
        public bool AirCondition { get; set; }
        public bool Tv { get; set; }

        public virtual ICollection<GuestRoom> GuestRooms { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
