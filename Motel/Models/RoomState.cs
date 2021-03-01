using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Motel.Models
{
    public partial class RoomState
    {
        public Guid Id { get; set; }
        public byte State { get; set; }
        public bool Type { get; set; }

        public virtual GuestRoom GuestRoom { get; set; }
    }
}
