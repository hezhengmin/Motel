using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public class OccupiedRoomDetailDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid RoomId { get; set; }
        public string RoomNumber { get; set; } //Room
        public string RoomTypeName { get; set; } //RoomType
        public string CustomerName { get; set; } //Customer
        public DateTime BeginDate { get; set; } //Reservation
        public DateTime EndDate { get; set; } //Reservation
        public int Expense { get; set; } //Reservation
        public DateTime? CheckInDate { get; set; } //OccupiedRoom
        public DateTime? CheckOutDate { get; set; } //OccupiedRoom
        public int? Pay { get; set; } //OccupiedRoom
        public bool Balance { get; set; } //OccupiedRoom
    }
}
