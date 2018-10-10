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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
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
        public ActionResult<Product> Get(int id)
        {
            return _productService.GetProductById(id);
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
            return _productService.UpdateProduct(id, product);
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            return _productService.DeleteProduct(id);
        }
    }
}