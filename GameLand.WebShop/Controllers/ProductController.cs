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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return _customService.GetAllCustomers();
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Order>> Get(int id)
        {
            return _customService.GetCustomerById(id);
        }

        // POST api/customers
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order customer)
        {
            return _customService.CreateCustomer(customer);
            
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order customer)
        {
            return _customService.UpdateCustomer(customer);
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            return _customService.DeleteCustomer(id);
        }
    }
}