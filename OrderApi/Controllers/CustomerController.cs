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
        private readonly ICustomerRepository customerService;
        public CustomerController(ICustomerRepository iCustomerService)
        {
            customerService = iCustomerService;
        }


        [HttpPost]
        public async Task<ActionResult<Customer>> saveCustomer(CustomerDto customerDto)
        {
           var result  =  customerService.saveCustomer(customerDto);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> getAllCustomers()
        {
          var result =  customerService.getAllCustomers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> getCustomer(int id)
        {
            var result = customerService.getCustomer(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> updateCustomer(CustomerDto customerDto)
        {
          var result =  customerService.updateCustomer(customerDto);
            return Ok(customerService.getAllCustomers());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Customer>>> deleteCustomer(int id)
        {
            
            return Ok(customerService.getAllCustomers());
        }

    }
}
