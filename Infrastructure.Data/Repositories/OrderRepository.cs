using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;
using WebShop.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly private WebShopDbContext _ctx;

        public OrderRepository(WebShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public Order CreateOrder(Order order)
        {
            if (order.Customer != null)
            {
                _ctx.Attach(order.Customer);
            }
            var order2Add = _ctx.Orders.Add(order).Entity;
            _ctx.SaveChanges();
            return order2Add;
        }

        public Order DeleteOrders(int idOrders)
        {
            var order2removeFromList = ReadOrderById(idOrders);
            var order2remove = _ctx.Orders.Remove(order2removeFromList).Entity;
            _ctx.SaveChanges();
            return order2remove;
        }

        public IEnumerable<Order> ReadOrder()
        {
            return _ctx.Orders;
        }

        public Order ReadOrderById(int id)
        {
            return _ctx.Orders.FirstOrDefault(o => o.Id == id);
        }

        public Order UpdateOrders(Order ordersToUpdate)
        {
            var uptade = _ctx.Orders.Update(ordersToUpdate).Entity;
            _ctx.SaveChanges();

            return ordersToUpdate;
        }
    }
}
