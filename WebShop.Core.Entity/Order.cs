using System.Transactions;

namespace WebShop.Core.Entity
{
    public class Order
    {
        public int Cid { get; set; }
        public int Pid { get; set; }
        public double Price { get; set; }
    }
}