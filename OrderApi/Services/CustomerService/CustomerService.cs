using EFModels.Models;
using Microsoft.EntityFrameworkCore;
using OrderApi.Dto;
using System.Runtime.CompilerServices;

namespace OrderApi.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ProductDBContext _dbContext;
        public CustomerService(ProductDBContext productDBContext)
        {
            _dbContext = productDBContext;
        }
        public async Task deleteCustomer(int id)
        {
            var dbCustomer = _dbContext.Customers.Find(id);
            if (dbCustomer == null)
            {
                return;
            }
             _dbContext.Customers.Remove(dbCustomer);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<Customer>> getAllCustomers()
        {
          
            var dbCustomers =  await _dbContext.Customers.ToListAsync();
            return dbCustomers;
        }

        public async Task<Customer> getCustomer(int id)
        {
            var dbCustomer =  await _dbContext.Customers.FindAsync(id);
            if (dbCustomer == null)
            {
                return null;
            }
            return dbCustomer;
        }

        public  async Task<Customer> saveCustomer(Customer customer)
        {
            
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> updateCustomer(CustomerDto customerDto)
        {
            var dbCustomer = await _dbContext.Customers.FindAsync(customerDto.Id);
            if (dbCustomer == null)
            {
                return null;
            }
            dbCustomer.Name = customerDto.Name;
            dbCustomer.Address = customerDto.Address;

            await _dbContext.SaveChangesAsync();
            return dbCustomer;
        }

        
    }
}
