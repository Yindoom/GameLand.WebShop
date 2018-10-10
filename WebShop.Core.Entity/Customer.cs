using System.Collections.Generic;

namespace WebShop.Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PreferredConsole { get; set; }
        public List<Order> Orders { get; set; }
        public string Password { get; set; }
    }
}