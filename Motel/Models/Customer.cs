using System;
using System.Collections.Generic;

#nullable disable

namespace Motel.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Occupies = new HashSet<Occupy>();
        }

        public Guid Id { get; set; }
        public string IdentityNum { get; set; }
        public bool Gender { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Occupy> Occupies { get; set; }
    }
}
