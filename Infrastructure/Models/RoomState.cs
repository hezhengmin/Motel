using Infrastructure.Enums;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Infrastructure.Models
{
    public partial class RoomState
    {
        public Guid Id { get; set; }
        public StateType StateType { get; set; }

        public virtual Room Room { get; set; }
    }
}
