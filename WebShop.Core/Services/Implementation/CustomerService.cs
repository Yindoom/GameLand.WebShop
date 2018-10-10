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
            if (customer.Name == null)
            {
                throw new ArgumentException("Name can not be empty.");
            }
            else if (customer.Email == null || customer.PhoneNumber.Equals(""))
            {
                throw new ArgumentException("A way to contact the user is a must.");
            }
            else if (customer.PreferredConsole != "PC" || customer.PreferredConsole != "PS4" || customer.PreferredConsole != "XBOX1")
            {
                throw new ArgumentException("We do not support this console yet at the store.");
            }
            return _customRepo.CreateCustomer(customer);
        }

        public Customer DeleteCustomer(int idCustomer)
        {
            if (idCustomer > 0)
            {
                return _customRepo.DeleteCustomer(idCustomer);
            }
            throw new ArgumentException("The ID you try to delete is not available.");
        }

        public List<Customer> GetAllCustomers()
        {
            return _customRepo.ReadCustomer().ToList();
        }

        public Customer GetCustomerById(int idCustomer)
        {

            if (idCustomer > 0)
            {
                var customer = _customRepo.ReadCustomerByID(idCustomer);
                return customer;
            }
            throw new ArgumentException("The ID you try to get is not available.");
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
