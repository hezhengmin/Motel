using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Motel.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Occupy = new HashSet<Occupy>();
        }

        public Guid Id { get; set; }
        public string IdentityNum { get; set; }
        public int Gender { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Occupy> Occupy { get; set; }
    }
}
