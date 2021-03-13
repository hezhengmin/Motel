using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Infrastructure.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Room = new HashSet<Room>();
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

        public virtual ICollection<Room> Room { get; set; }
    }
}
