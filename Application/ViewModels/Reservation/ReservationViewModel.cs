using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Application.ViewModels.Reservation
{
    public class ReservationViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid CustomerId { get; set; }
        
        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "預訂日期")]
        public DateTime BeginDate { get; set; }

        [Range(1, 255)]
        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "預訂天數")]
        public byte Days { get; set; }

        [Display(Name = "登記")]
        public bool CheckIn { get; set; }
    }
}
