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

            if (string.IsNullOrEmpty(customer.Name))
            {
                throw new ArgumentException("Name can not be empty.");
            }
            else if (string.IsNullOrEmpty(customer.Email))
            {
                throw new ArgumentException("A valid way to contact the user is a must.");
            }
            else if (!customer.PreferredConsole.Equals("PC") && !customer.PreferredConsole.Equals("PS4") && !customer.PreferredConsole.Equals("XBOX1"))
            {
                throw new ArgumentException("We do not support this console yet at the store.");
            }
            else if (string.IsNullOrEmpty(customer.Password) || !customer.Password.Any(char.IsDigit))
            {
                throw new ArgumentException("Password not secure enough, try add at least one number");
            }
            else if (customer.Password.Length < 4 || customer.Password.Length > 16)
            {
                throw new ArgumentException("Password must be between 4 and 15 digits.");
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
                return _customRepo.ReadCustomerByID(idCustomer);

            }
            throw new ArgumentException("The ID you try to get is not available.");

        }

        public Customer UpdateCustomer(int id, Customer customerToUpdate)
        {
            customerToUpdate.Id = id;
            return _customRepo.UpdateCustomer(customerToUpdate);
        }
    }
}
