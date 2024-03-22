using EFModels.Models;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Dto;

namespace OrderApi.Services.CustomerService
{
    public interface ICustomerService
    {
        Customer saveCustomer(CustomerDto customerDto);
       List<Customer> getAllCustomers();

        Customer getCustomer(int id);

        Customer updateCustomer(CustomerDto customerDto);

        void deleteCustomer(int id);
    }
}
