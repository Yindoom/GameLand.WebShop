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
            return _orderRepo.CreateOrder(order);
        }

        public Order DeleteOrders(int idOrder)
        {
            return _orderRepo.DeleteOrders(idOrder);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.ReadOrder().ToList();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepo.ReadOrderById(id);
        }

        public Order UpdateOrders(Order orderToUpdate)
        {
            return _orderRepo.UpdateOrders(orderToUpdate);
        }
    }
}
