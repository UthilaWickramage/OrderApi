using EFModels.Models;
using Microsoft.EntityFrameworkCore;
using OrderApi.Dto;

namespace OrderApi.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ProductDBContext _dbContext;

        public CustomerService(ProductDBContext productDBContext)
        {
            _dbContext = productDBContext;
        }
        public void deleteCustomer(int id)
        {
            var dbCustomer = _dbContext.Customers.Find(id);
            if (dbCustomer == null)
            {
                return;
            }
            _dbContext.Customers.Remove(dbCustomer);
           _dbContext.SaveChangesAsync();
            
        }

        public List<Customer> getAllCustomers()
        {
            var dbCustomers = _dbContext.Customers.ToList();
            return dbCustomers;
        }

        public Customer getCustomer(int id)
        {
            var dbCustomer =  _dbContext.Customers.Find(id);
            if (dbCustomer == null)
            {
                return null;
            }
            return dbCustomer;
        }

        public  Customer saveCustomer(CustomerDto customerDto)
        {
            Customer customer = new Customer();
            customer.Name = customerDto.Name;
            customer.Address = customerDto.Address;
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public Customer updateCustomer(CustomerDto customerDto)
        {
            var dbCustomer =  _dbContext.Customers.Find(customerDto.Id);
            if (dbCustomer == null)
            {
                return null;
            }
            dbCustomer.Name = customerDto.Name;
            dbCustomer.Address = customerDto.Address;

           _dbContext.SaveChanges();
            return dbCustomer;
        }
    }
}
