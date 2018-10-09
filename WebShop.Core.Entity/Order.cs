using System.Collections.Generic;
using System.Transactions;

namespace WebShop.Core.Entity
{
    public class Order
    {
        public Customer customer { get; set; }
        public List<Product> products { get; set; }
        public double Price { get; set; }
    }
}