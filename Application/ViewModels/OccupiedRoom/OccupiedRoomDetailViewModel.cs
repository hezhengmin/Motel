using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.OccupiedRoom
{
    public class OccupiedRoomDetailViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid RoomId { get; set; }

        [Display(Name = "房間號：")]
        public string RoomNumber { get; set; } //Room

        [Display(Name = "房間類型：")]
        public string RoomTypeName { get; set; } //RoomType

        [Display(Name = "客戶姓名：")]
        public string CustomerName { get; set; } //Customer

        [Display(Name = "預訂開始日期：")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BeginDate { get; set; }　//Reservation

        [Display(Name = "預訂結束日期：")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; } //Reservation

        [Display(Name = "住宿費：")]
        public int Expense { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "入住日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? CheckInDate { get; set; } //OccupiedRoom

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "退房日期")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? CheckOutDate { get; set; } //OccupiedRoom

        [Display(Name = "結算金額")]
        public int? Pay { get; set; } //OccupiedRoom
    }
}
