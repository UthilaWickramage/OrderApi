using EFModels.Models;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Dto;

namespace OrderApi.Services.CustomerService
{
    public interface ICustomerRepository
    {
        Customer saveCustomer(Customer customerDto);
       List<Customer> getAllCustomers();

        Customer getCustomer(int id);

        Customer updateCustomer(CustomerDto customerDto);

        void deleteCustomer(int id);
    }
}
