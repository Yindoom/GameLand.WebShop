using System.Collections.Generic;
using System.Transactions;

namespace WebShop.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public Customer customer { get; set; }
        public List<Product> products { get; set; }
        public object customer;

        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public double Price { get; set; }
    }
}