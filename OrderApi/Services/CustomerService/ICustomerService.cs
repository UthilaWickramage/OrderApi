using EFModels.Models;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Dto;

namespace OrderApi.Services.CustomerService
{
    public interface ICustomerService
    {
         Task<Customer> saveCustomer(Customer customer);
      Task<List<Customer>> getAllCustomers();

        Task<Customer> getCustomer(int id);

        Task<Customer> updateCustomer(CustomerDto customerDto);

        Task deleteCustomer(int id);
    }
}
