using AutoMapper;
using Application.ViewModels.Customer;
using Application.Repository;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository CustomerRepository)
        {
            _mapper = mapper;
            _customerRepository = CustomerRepository;
        }

        public async Task<CustomerViewModel> GetCustomer(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetCustomer(id));
        }

        public async Task<List<CustomerViewModel>> GetCustomerList()
        {
            return _mapper.Map<List<CustomerViewModel>>(await _customerRepository.GetCustomerList());
        }

        public async Task<CustomerIndexViewModel> GetCustomerList(int pageNumber, int pageSize)
        {
            var query = _mapper.Map<CustomerIndexViewModel>(await _customerRepository.GetCustomerList(pageNumber, pageSize));
            return query;
        }

        public async Task<CustomerIndexViewModel> GetCustomerList(FilterViewModel filterVM, int pageSize)
        {
            var pageNumber = filterVM.PageNumber == 0 ? 1 : filterVM.PageNumber;
            var query = _mapper.Map<CustomerIndexViewModel>(await _customerRepository.GetCustomerList(filterVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(filterVM.SearchString))
                query.SearchString = filterVM.SearchString;

            return query;
        }

        public async Task<CustomerIndexViewModel> GetCustomerList(CustomerIndexViewModel customerIndexVM, int pageSize)
        {
            var pageNumber = customerIndexVM.PageNumber == 0 ? 1 : customerIndexVM.PageNumber;
            var query = _mapper.Map<CustomerIndexViewModel>(await _customerRepository.GetCustomerList(customerIndexVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(customerIndexVM.SearchString))
                query.SearchString = customerIndexVM.SearchString;

            return query;
        }

        public async Task<CustomerIndexViewModel> GetCustomerList(CustomerDeleteViewModel customerDeleteVM, int pageSize)
        {
            var pageNumber = customerDeleteVM.PageNumber == 0 ? 1 : customerDeleteVM.PageNumber;
            var query = _mapper.Map<CustomerIndexViewModel>(await _customerRepository.GetCustomerList(customerDeleteVM.SearchString, pageNumber, pageSize));

            if (!string.IsNullOrEmpty(customerDeleteVM.SearchString))
                query.SearchString = customerDeleteVM.SearchString;

            return query;
        }

        public async Task AddCustomer(CustomerViewModel customerVM)
        {
            var customer = _mapper.Map<Customer>(customerVM);
            await _customerRepository.AddCustomer(customer);
        }

        public async Task UpdateCustomer(CustomerViewModel customerVM)
        {
            var entity = await _customerRepository.GetCustomer(customerVM.Id);

            var customer = _mapper.Map(customerVM, entity);

            await _customerRepository.UpdateCustomer(customer);
        }

        public async Task RemoveCustomer(Guid id)
        {
            await _customerRepository.RemoveCustomer(id);
        }

        public bool GetCustomerExists(Guid id)
        {
            return _customerRepository.GetCustomerExists(id);
        }
    }
}
