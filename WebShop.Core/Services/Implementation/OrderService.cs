using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Core.Domain;
using WebShop.Core.Entity;

namespace WebShop.Core.Services.Implementation
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public Order CreateOrders(Order order)
        {
            if (order.Customer != null)
            {
            return _orderRepo.CreateOrder(order);
            }
            throw new ArgumentException("Order must be attached to some customer");
        }

        public Order DeleteOrders(int idOrder)
        {
            if (idOrder <= 0)
            {
                throw new ArgumentException("The order you try to delete is not available");
            }
            return _orderRepo.DeleteOrders(idOrder);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.ReadOrder().ToList();
        }

        public Order GetOrderById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("The order you try to get is not available");
            }
            return _orderRepo.ReadOrderById(id);
        }

        public Order UpdateOrders(Order orderToUpdate)
        {
            return _orderRepo.UpdateOrders(orderToUpdate);
        }
    }
}
