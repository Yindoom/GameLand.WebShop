using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var customer2removeFromList = ReadCustomerByID(idCustomer);
            var customer2remove = _ctx.Customers.Remove(customer2removeFromList).Entity;
            _ctx.SaveChanges();
            return customer2remove;
        }

        public IEnumerable<Customer> ReadCustomer()
        {
            return _ctx.Customers;
        }

        public Customer ReadCustomerByID(int id)
        {
            return _ctx.Customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            _ctx.Attach(customerToUpdate).State = EntityState.Modified;
            _ctx.Entry(customerToUpdate).Reference(c => c.Orders).IsModified = true;
            _ctx.SaveChanges();

            return customerToUpdate;
        }
    }
}
