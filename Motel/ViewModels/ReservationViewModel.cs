using Motel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.ViewModels
{
    public class ReservationViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public RoomType RoomType { get; set; }

        [Required]
        public DateTime BeginDate { get; set; }

        [Required]
        public byte Days { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Tel { get; set; }

        [Required]
        public bool CheckIn { get; set; }

        [Required]
        public string RoomNumber { get; set; }
    }
}
