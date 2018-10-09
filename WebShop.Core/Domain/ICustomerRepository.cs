using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;

namespace WebShop.Core.Domain
{
    public interface ICustomerRepository
    {
        Customer ReadCustomerByID(int id);
        Customer CreateCustomer(Customer customer);
        IEnumerable<Customer> ReadCustomer();
        Customer UpdateCustomer(Customer customerToUpdate);
        Customer DeleteCustomer(int idCustomer);
    }
}
