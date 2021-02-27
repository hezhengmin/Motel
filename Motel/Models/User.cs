using System;
using System.Collections.Generic;

#nullable disable

namespace Motel.Models
{
    public partial class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public int Power { get; set; }
    }
}
