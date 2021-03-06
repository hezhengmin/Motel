using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Motel.ViewModels.Enums
{
    public enum GenderType
    {
        [Display(Name = "男")]
        [EnumMember(Value = "男")]
        Male,
        [Display(Name = "女")]
        [EnumMember(Value = "女")]
        Female
    }
}
