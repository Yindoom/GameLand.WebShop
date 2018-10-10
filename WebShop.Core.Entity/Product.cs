using System;
using System.Collections.Generic;

namespace WebShop.Core.Entity
{
    public class Product
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Console { get; set; }
        public string Image { get; set; }
    }
}