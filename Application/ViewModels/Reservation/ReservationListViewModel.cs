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
