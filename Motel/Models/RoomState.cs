using System;
using System.Collections.Generic;

#nullable disable

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
