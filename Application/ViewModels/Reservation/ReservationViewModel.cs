using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Application.ViewModels.Reservation
{
    public class ReservationViewModel : IValidatableObject
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "房間號碼")]
        public Guid? RoomId { get; set; }
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "預訂開始日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BeginDate { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "預訂結束日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Range(1, 255)]
        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "預訂天數")]
        public byte Days { get; set; }

        [Display(Name = "登記")]
        public bool CheckIn { get; set; }

        public List<SelectListItem> RoomList { get; set; }
        public List<SelectListItem> RoomTypeList { get; set; }
        [Display(Name = "房間類型")]
        public Guid? RoomTypeId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BeginDate > EndDate)
            {
                yield return new ValidationResult("結束日期不能小於開始日期",
                new[] { nameof(EndDate), nameof(BeginDate) });
            }
        }
    }
}
