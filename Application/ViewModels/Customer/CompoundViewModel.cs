using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Customer
{
    public class CompoundViewModel
    {
        public CustomerViewModel CustomerViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
