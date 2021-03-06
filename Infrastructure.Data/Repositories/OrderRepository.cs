﻿using System;
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

            _ctx.Attach(order.Product);
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
            return _ctx.Orders.Include(o => o.Product).Include(o => o.Customer);
        }

        public Order ReadOrderById(int id)
        {
            return _ctx.Orders.FirstOrDefault(o => o.Id == id);
        }

        public void DeleteAllProductOrders(Product delProduct)
        {
            foreach (var order in _ctx.Orders.Where(o => o.Product.Id == delProduct.Id))
            {
                order.Product = null;
                _ctx.Update(order);
            }
            _ctx.SaveChanges();
        }

        public Order UpdateOrders(Order ordersToUpdate)
        {
            var update = _ctx.Orders.Update(ordersToUpdate).Entity;
            _ctx.SaveChanges();

            return update;
        }
    }
}
