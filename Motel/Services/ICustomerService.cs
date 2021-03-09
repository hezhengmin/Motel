using Motel.Repository;
using Motel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Services
{
    public interface ICustomerService
    {
        Task<CustomerViewModel> GetCustomer(Guid id);
        Task<List<CustomerViewModel>> GetCustomerList();
        Task<CustomerIndexViewModel> GetCustomerList(int pageNumber, int pageSize);
        Task<CustomerIndexViewModel> GetCustomerList(CustomerIndexViewModel customerIndexVM, int pageSize);
        Task AddCustomer(CustomerViewModel customerVM);
        Task UpdateCustomer(CustomerViewModel customerVM);
        Task RemoveCustomer(Guid id);
        bool GetCustomerExists(Guid id);
    }
}
