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
        Task AddCustomer(CustomerViewModel CustomerVM);
        Task UpdateCustomer(CustomerViewModel CustomerVM);
        Task RemoveCustomer(Guid id);
        bool GetCustomerExists(Guid id);
    }
}
