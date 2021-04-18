using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Application.ViewModels.Reservation
{
    public class ReservationViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "房間號碼")]
        public Guid RoomId { get; set; }
        public Guid CustomerId { get; set; }
        
        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "預訂日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BeginDate { get; set; }

        [Range(1, 255)]
        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "預訂天數")]
        public byte Days { get; set; }

        [Display(Name = "登記")]
        public bool CheckIn { get; set; }

        public List<SelectListItem> RoomList { get; set; }
    }
}
