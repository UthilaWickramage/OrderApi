using OrderApi.Dto;
using EFModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderApi.Services.CustomerService;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService iCustomerService)
        {
            customerService = iCustomerService;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> saveCustomer(CustomerDto customerDto)
        {
            Customer customer = new Customer();
            customer.Name = customerDto.Name;
            customer.Address = customerDto.Address;
            var result  = await customerService.saveCustomer(customer);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> getAllCustomers()
        {
          var result =  await customerService.getAllCustomers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> getCustomer(int id)
        {
            var result = await customerService.getCustomer(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> updateCustomer(CustomerDto customerDto)
        {
          var result =  await customerService.updateCustomer(customerDto);
            return Ok(await customerService.getAllCustomers());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Customer>>> deleteCustomer(int id)
        {
            await customerService.deleteCustomer(id);
            return Ok();
        }

    }
}
