using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ViewModels.RoomType
{
    public class RoomTypeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "類型名稱")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "房間面積")]
        public double? Area { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "配備床數")]
        public int? BedQuantity { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "平日價")]
        public int? Price { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "假日價")]
        public int? Hprice { get; set; }

        [Required]
        [Display(Name = "是否有空調")]
        public bool AirCondition { get; set; }

        [Required]
        [Display(Name = "是否有電視")]
        public bool Tv { get; set; }
    }
}
