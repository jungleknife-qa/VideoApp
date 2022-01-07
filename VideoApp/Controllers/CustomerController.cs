using VideoApp.DBContexts;
using VideoApp.Models;
using VideoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Customer/GetCustomers")]
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerService.GetCustomers();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Customer/AddCustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerService.AddCustomer(customer);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Customer/UpdateCustomer")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerService.UpdateCustomer(customer);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        [Route("api/Customer/DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            var existingCustomer = _customerService.GetCustomer(id);
            if (existingCustomer != null)
            {
                _customerService.DeleteCustomer(existingCustomer.Id);
                return Ok();
            }
            return NotFound($"Customer not found with ID : {existingCustomer.Id}");
        }
        [HttpGet]
        [Route("GetCustomer")]
        public Customer GetCustomer(int id)
        {
            return _customerService.GetCustomer(id);
        }
    }
}
