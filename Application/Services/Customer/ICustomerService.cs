using Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICustomerService
    {
        Task<CustomerViewModel> GetCustomer(Guid id);
        //多載相同名稱的建構子或方法，提供不同參數列。Ex：GetCustomerList()、GetCustomerList(int pageNumber, int pageSize)
        Task<List<CustomerViewModel>> GetCustomerList();
        Task<CustomerIndexViewModel> GetCustomerList(int pageNumber, int pageSize);
        Task<CustomerIndexViewModel> GetCustomerList(FilterViewModel filterVM, int pageSize);
        Task<CustomerIndexViewModel> GetCustomerList(CustomerDeleteViewModel customerDeleteVM, int pageSize);
        Task<CustomerIndexViewModel> GetCustomerList(CustomerIndexViewModel customerIndexVM, int pageSize);
        Task AddCustomer(CustomerViewModel customerVM);
        Task UpdateCustomer(CustomerViewModel customerVM);
        Task RemoveCustomer(Guid id);
        bool GetCustomerExists(Guid id);
    }
}
