using EFModels.Models;
using OrderApi.Dto;

namespace OrderApi.Services.CustomerService
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ProductDBContext _dbContext;
        public CustomerRepository(ProductDBContext productDBContext)
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
            var dbCustomer = _dbContext.Customers.Find(id);
            if (dbCustomer == null)
            {
                return null;
            }
            return dbCustomer;
        }

        public Customer saveCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public Customer updateCustomer(CustomerDto customer)
        {
            var dbCustomer = _dbContext.Customers.Find(customer.Id);
            if (dbCustomer == null)
            {
                return null;
            }
            dbCustomer.Name = customer.Name;
            dbCustomer.Address = customer.Address;

            _dbContext.SaveChanges();
            return dbCustomer;
        }
    }
}
