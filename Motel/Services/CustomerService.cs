﻿using AutoMapper;
using Motel.Models;
using Motel.Repository;
using Motel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _CustomerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository CustomerRepository)
        {
            _mapper = mapper;
            _CustomerRepository = CustomerRepository;
        }

        public async Task<CustomerViewModel> GetCustomer(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(await _CustomerRepository.GetCustomer(id));
        }

        public async Task<List<CustomerViewModel>> GetCustomerList()
        {
            return _mapper.Map<List<CustomerViewModel>>(await _CustomerRepository.GetCustomerList());
        }

        public async Task<CustomerIndexViewModel> GetCustomerList(int pageNumber, int pageSize)
        {
            var customerIndexVM = _mapper.Map<CustomerIndexViewModel>(await _CustomerRepository.GetCustomerList(pageNumber, pageSize));
            return customerIndexVM;
        }

        public async Task AddCustomer(CustomerViewModel customerVM)
        {
            var Customer = _mapper.Map<Customer>(customerVM);
            await _CustomerRepository.AddCustomer(Customer);
        }
        public async Task UpdateCustomer(CustomerViewModel customerVM)
        {
            var Customer = _mapper.Map<Customer>(customerVM);
            await _CustomerRepository.UpdateCustomer(Customer);
        }

        public async Task RemoveCustomer(Guid id)
        {
            await _CustomerRepository.RemoveCustomer(id);
        }

        public bool GetCustomerExists(Guid id)
        {
            return _CustomerRepository.GetCustomerExists(id);
        }


    }
}
