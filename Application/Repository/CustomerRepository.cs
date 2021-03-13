using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Models;
using Application.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MotelDbContext _dbContext;

        public CustomerRepository(MotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> GetCustomer(Guid id)
        {
            return await _dbContext.Customer.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Customer>> GetCustomerList()
        {
            return await _dbContext.Customer.ToListAsync();
        }

        public async Task<PaginatedList<Customer>> GetCustomerList(int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Customer>().AsQueryable();
            var list =  await PaginatedList<Customer>.CreateAsync(query, pageNumber, pageSize);
            return list;
        }

        public async Task<PaginatedList<Customer>> GetCustomerList(string searchString, int pageNumber, int pageSize)
        {
            var query = _dbContext.Set<Customer>().AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.Name.Contains(searchString));
            }

            var list = await PaginatedList<Customer>.CreateAsync(query, pageNumber, pageSize);
            
            return list;
        }

        public async Task AddCustomer(Customer customer)
        {
            _dbContext.Add(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            _dbContext.Update(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveCustomer(Guid id)
        {
            var customer = await GetCustomer(id);
            if (customer != null)
            {
                _dbContext.Customer.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
        }

        public bool GetCustomerExists(Guid id)
        {
            return _dbContext.Customer.Any(m => m.Id == id);
        }
    }
}
