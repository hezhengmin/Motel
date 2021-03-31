using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels.Enums;
using Application.ViewModels.RoomType;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Application.ViewModels.Room
{
    public class RoomViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "房間號")]
        [StringLength(10)]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "房間類型")]
        public Guid RoomTypeId { get; set; }

        [StringLength(50)]
        [Display(Name = "房間描述")]
        public string Describe { get; set; }

        [StringLength(50)]
        [Display(Name = "房間位置")]
        public string Position { get; set; }

        public List<SelectListItem> RoomTypeList { get; set; }

        public RoomTypeViewModel RoomType { get; set; }
    }
}
