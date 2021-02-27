using System;
using System.Collections.Generic;

#nullable disable

namespace Motel.Models
{
    public partial class GuestRoom
    {
        public GuestRoom()
        {
            Occupies = new HashSet<Occupy>();
        }

        public Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public Guid RoomTypeId { get; set; }
        public string Describe { get; set; }
        public string Position { get; set; }

        public virtual RoomState IdNavigation { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<Occupy> Occupies { get; set; }
    }
}
