using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Motel.Models
{
    public partial class GuestRoom
    {
        public GuestRoom()
        {
            Occupy = new HashSet<Occupy>();
        }

        public Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public Guid RoomTypeId { get; set; }
        public string Describe { get; set; }
        public string Position { get; set; }

        public virtual RoomState IdNavigation { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<Occupy> Occupy { get; set; }
    }
}
