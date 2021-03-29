using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ViewModels.RoomType
{
    public class RoomTypeViewModel
    {
        public Guid Id { get; set; }

        [Required]
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
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "假日價")]
        public decimal? Hprice { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "休息價(元/3hr)")]
        public decimal? Qkprice { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "休息價(元/2hr)")]
        public decimal? Qk2price { get; set; }

        [Required]
        [Display(Name = "是否有空調")]
        public bool AirCondition { get; set; }

        [Required]
        [Display(Name = "是否有電視")]
        public bool Tv { get; set; }
    }
}
