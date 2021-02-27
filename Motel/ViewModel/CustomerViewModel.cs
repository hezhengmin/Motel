using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.ViewModel
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string IdentityNum { get; set; }
        public bool Gender { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
    }
}
