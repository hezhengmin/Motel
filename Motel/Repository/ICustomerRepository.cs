﻿using Motel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(Guid id);
        Task<List<Customer>> GetCustomerList();
        Task<PaginatedList<Customer>> GetCustomerList(int pageNumber, int pageSize);
        Task AddCustomer(Customer Customer);
        Task UpdateCustomer(Customer Customer);
        Task RemoveCustomer(Guid id);
        bool GetCustomerExists(Guid id);
    }
}
