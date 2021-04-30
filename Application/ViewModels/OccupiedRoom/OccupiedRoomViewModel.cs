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
        
    }
}
