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

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _productService.GetAllProducts();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Product>> Get(int id)
        {
            return _productService.;
        }

        // POST api/products
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            return _productService.CreateProduct(product);
            
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product product)
        {
            return _productService.UpdateProduct(product);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            return _productService.DeleteProduct(id);
        }
    }
}