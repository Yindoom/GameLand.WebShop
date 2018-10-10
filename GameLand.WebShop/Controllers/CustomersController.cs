using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Entity;
using WebShop.Core.Service;

namespace GameLand.WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customService;
        public CustomersController(ICustomerService customService)
        {
            _customService = customService;
        }

        // GET api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return _customService.GetAllCustomers();
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Customer>> Get(int id)
        {
            return _customService.GetCustomerById(id);
        }

        // POST api/customers
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            return _customService.CreateCustomer(customer);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            return _customService.UpdateCustomer(customer);
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            return _customService.DeleteCustomer(id);
        }
    }
}