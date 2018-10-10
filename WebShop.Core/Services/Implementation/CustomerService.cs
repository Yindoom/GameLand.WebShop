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

        public Customer GetCustomerById(int idCustomer)
        {
            return _customRepo.ReadCustomerByID(idCustomer);
        }

        public Customer UpdateCustomer(int id, Customer customerToUpdate)
        {
            customerToUpdate.Id = id;
            return _customRepo.UpdateCustomer(customerToUpdate);
        }
    }
}
