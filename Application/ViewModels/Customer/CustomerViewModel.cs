using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Application.ViewModels.Customer
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [StringLength(10)]
        [RegularExpression(@"^[A-Z]{1}[1-2]{1}[0-9]{8}$")]
        [Display(Name = "客戶身份證字號")]
        public string IdentityNum { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [JsonConverter(typeof(StringEnumConverter))]
        [Display(Name = "性別")]
        public GenderType Gender { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [StringLength(10)]
        [Display(Name = "客戶姓名")]
        public string Name { get; set; }

        [Display(Name = "客戶住址")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "客戶電話")]
        public string Tel { get; set; }
    }
}
