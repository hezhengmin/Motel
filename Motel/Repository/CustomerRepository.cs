using Microsoft.EntityFrameworkCore;
using Motel.Data;
using Motel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motel.Repository
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

        public async Task AddCustomer(Customer Customer)
        {
            _dbContext.Add(Customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer Customer)
        {
            _dbContext.Update(Customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveCustomer(Guid id)
        {
            var Customer = await GetCustomer(id);
            if (Customer != null)
            {
                _dbContext.Customer.Remove(Customer);
                await _dbContext.SaveChangesAsync();
            }
        }

        public bool GetCustomerExists(Guid id)
        {
            return _dbContext.Customer.Any(m => m.Id == id);
        }
    }
}
