using EFModels.Models;
using Microsoft.EntityFrameworkCore;
using OrderApi.Dto;

namespace OrderApi.Services.CustomerService
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository repository)
        {
           _customerRepository = repository;
        }
        public void deleteCustomer(int id)
        {
           _customerRepository.deleteCustomer(id);
            
        }

        public List<Customer> getAllCustomers()
        {
           return _customerRepository.getAllCustomers();
        }

        public Customer getCustomer(int id)
        {
           return _customerRepository.getCustomer(id);
        }

        public  Customer saveCustomer(CustomerDto customerDto)
        {
            Customer customer = new Customer();
            customer.Name = customerDto.Name;
            customer.Address = customerDto.Address;
           return _customerRepository.saveCustomer(customer);
        }

        public Customer updateCustomer(CustomerDto customerDto)
        {
            return _customerRepository.updateCustomer(customerDto);
        }
    }
}
