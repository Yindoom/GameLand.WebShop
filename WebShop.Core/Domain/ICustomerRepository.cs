using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;

namespace WebShop.Core.Domain
{
    public interface ICustomerRepository
    {

        Customer CreateCustomer(Customer customer);
        Customer ReadCustomer(int id);
        Customer UpdateCustomer(Customer customerToUpdate);
        Customer DeleteCustomer(int idCustomer);
    }
}
