﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Customer
{
    public class CustomerDeleteViewModel
    {
        public Guid Id { get; set; }
        public int PageNumber { get; set; }
        public string SearchString { get; set; }
    }
}
