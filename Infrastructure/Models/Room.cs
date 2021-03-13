using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Infrastructure.Models
{
    public partial class Room
    {
        public Room()
        {
            OccupiedRoom = new HashSet<OccupiedRoom>();
            Reservation = new HashSet<Reservation>();
        }

        public Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public Guid RoomTypeId { get; set; }
        public string Describe { get; set; }
        public string Position { get; set; }

        public virtual RoomType RoomType { get; set; }
        public virtual RoomState RoomState { get; set; }
        public virtual ICollection<OccupiedRoom> OccupiedRoom { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
