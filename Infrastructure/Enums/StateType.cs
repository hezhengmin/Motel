using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Infrastructure.Enums
{
    public enum StateType : int
    {
        [Display(Name = "空房中")]
        [EnumMember(Value = "空房中")]
        Vacancy,
        [Display(Name = "住房中")]
        [EnumMember(Value = "住房中")]
        Stay,
        [Display(Name = "清潔中")]
        [EnumMember(Value = "清潔中")]
        Cleaning
    }
}
