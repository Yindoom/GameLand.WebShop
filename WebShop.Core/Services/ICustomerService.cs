﻿using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;

namespace WebShop.Core.Service
{
    public interface ICustomerService
    {
        Customer CreateCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer UpdateCustomer(int id, Customer customerToUpdate);
        Customer DeleteCustomer(int idCustomer);
        Customer GetCustomerById(int idCustomer);

    }
}
