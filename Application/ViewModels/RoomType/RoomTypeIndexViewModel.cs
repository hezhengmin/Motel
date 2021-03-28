using Application.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ViewModels.RoomType
{
    public class RoomTypeIndexViewModel
    {
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public PaginatedList<RoomTypeViewModel> RoomTypeViewModelList { get; set; }
    }
}
