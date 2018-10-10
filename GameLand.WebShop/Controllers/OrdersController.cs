using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Core.Entity;
using WebShop.Core.Service;
using WebShop.Core.Services;

namespace GameLand.WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET api/orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return _orderService.GetAllOrders();
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return _orderService.GetOrderById(id);
        }

        // POST api/orders
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            return _orderService.CreateOrders(order);
        }

        // PUT api/orders/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order order)
        {
            return _orderService.UpdateOrders(order);
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            return _orderService.DeleteOrders(id);
        }
    }
}