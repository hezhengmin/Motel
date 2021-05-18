using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.OccupiedRoom
{
    public class OccupiedRoomListViewModel
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

        [Display(Name = "房間號碼")]
        public string RoomNumber { get; set; }

        [Display(Name = "類型名稱")]
        public string RoomTypeName { get; set; }

        [Display(Name = "預訂開始日期")]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }

        [Display(Name = "預訂結束日期")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "預訂天數")]
        public int Days { get; set; }

        [Display(Name = "住宿費")]
        public int Expense { get; set; }
    }
}
