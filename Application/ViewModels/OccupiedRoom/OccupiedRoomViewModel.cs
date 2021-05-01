using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels.Enums;
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
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public decimal? Pay { get; set; }
        public decimal? PrePay { get; set; }
        public decimal? Price { get; set; }
        public int? Days { get; set; }
        public bool Balance { get; set; }
    }
}
