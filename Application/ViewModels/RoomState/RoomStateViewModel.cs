using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Application.ViewModels.RoomState
{
    public class RoomStateViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [Display(Name = "房間狀態")]
        public StateType StateType { get; set; }
    }
}
