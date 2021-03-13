using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Application.ViewModels.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Application.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "客戶身份證字號")]
        [StringLength(10)]
        [RegularExpression(@"^[A-Z]{1}[1-2]{1}[0-9]{8}$")]
        public string IdentityNum { get; set; }

        [Required]
        [Display(Name = "性別")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GenderType Gender { get; set; }

        [Required]
        [Display(Name = "客戶姓名")]
        [StringLength(10)]
        public string Name { get; set; }

        [Display(Name = "客戶住址")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "客戶電話")]
        public string Tel { get; set; }
    }
}
