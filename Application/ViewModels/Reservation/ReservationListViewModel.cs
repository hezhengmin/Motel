using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Reservation
{
    public class ReservationListViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "房間號碼")]
        public string RoomNumber { get; set; }

        [Display(Name = "類型名稱")]
        public string RoomTypeName { get; set; }

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
