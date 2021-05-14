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

        [Display(Name = "房間號")]
        public string RoomNumber { get; set; } //Room

        [Display(Name = "房間類型")]
        public string RoomTypeName { get; set; } //RoomType

        [Display(Name = "客戶姓名")]
        public string CustomerName { get; set; } //Customer

        [Display(Name = "入住日期")]
        public DateTime? CheckInDate { get; set; } //OccupiedRoom

        [Display(Name = "退房日期")]
        public DateTime? CheckOutDate { get; set; } //OccupiedRoom

        [Display(Name = "結算金額")]
        public int? Pay { get; set; } //OccupiedRoom

        [Display(Name = "住宿天數")]
        public int? Days { get; set; } //OccupiedRoom

        [Display(Name = "是否需補差額")]
        public bool Balance { get; set; } //OccupiedRoom
    }
}
