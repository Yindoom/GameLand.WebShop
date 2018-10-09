using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Domain;
using WebShop.Core.Entity;

namespace Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        readonly private WebShopDbContext _ctx;

        public Customer CreateCustomer(Customer customer)
        {
           if(customer.Orders != null)
            {
                _ctx.Attach(customer.Orders);
            }
            var customer2Add = _ctx.Customers.Add(customer).Entity;
            _ctx.SaveChanges();
            return customer2Add;
        }

        public Customer DeleteCustomer(int idCustomer)
        {
            throw new NotImplementedException();
        }

        public Customer ReadCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
