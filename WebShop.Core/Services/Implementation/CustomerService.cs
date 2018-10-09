using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Core.Domain;
using WebShop.Core.Entity;
using WebShop.Core.Service;

namespace WebShop.Core.Services.Implementation
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customRepo;

        public CustomerService(ICustomerRepository customRepo)
        {
            _customRepo = customRepo;
        }

        public Customer CreateCustomer(Customer customer)
        {
            return _customRepo.CreateCustomer(customer);
        }

        public Customer DeleteCustomer(int idCustomer)
        {
            return _customRepo.DeleteCustomer(idCustomer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customRepo.ReadCustomer().ToList();
        }

        public List<Customer> GetCustomerById(int idCustomer)
        {
            var list = _customRepo.ReadCustomer();
            var customer = list.Where(c => c.Id.Equals(idCustomer));
            return customer.ToList();
        }

        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            var customer = _customRepo.ReadCustomerByID(customerToUpdate.Id);
            customer.Name = customerToUpdate.Name;
            customer.Email = customerToUpdate.Email;
            customer.Address = customerToUpdate.Address;
            customer.PreferredConsole = customerToUpdate.PreferredConsole;
            customer.Orders = customerToUpdate.Orders;
            return customer;
        }
    }
}
