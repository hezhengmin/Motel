using Application.Paging;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(Guid id);
        Task<List<Customer>> GetCustomerList();
        Task<PaginatedList<Customer>> GetCustomerList(int pageNumber, int pageSize);
        Task<PaginatedList<Customer>> GetCustomerList(string searchString, int pageNumber, int pageSize);
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task RemoveCustomer(Guid id);
        bool GetCustomerExists(Guid id);
    }
}
