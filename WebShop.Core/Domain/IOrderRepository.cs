using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;

namespace WebShop.Core.Domain
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        IEnumerable<Order> ReadOrder();
        Order UpdateOrders(Order ordersToUpdate);
        Order DeleteOrders(int idOrders);
        Order ReadOrderById(int id);
    }
}
