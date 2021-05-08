using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Application.ViewModels.OccupiedRoom
{
    public class OccupiedRoomViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid RoomId { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "入住日期")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "退房日期")]
        public DateTime? CheckOutDate { get; set; }

        [Display(Name = "結算金額")]
        public int? Pay { get; set; }

        [Display(Name = "住宿天數")]
        public int? Days { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "是否需補差額")]
        public bool Balance { get; set; }
    }
}
