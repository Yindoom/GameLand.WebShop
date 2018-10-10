using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;

namespace WebShop.Core.Services
{
    public interface IOrderService
    {
        Order CreateOrders(Order order);
        List<Order> GetAllOrders();
        Order UpdateOrders(Order orderToUpdate);
        Order DeleteOrders(int idOrder);
        Order GetOrderById(int idOrder);
    }
}
