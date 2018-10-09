using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShop.Core;
using WebShop.Core.Domain;
using WebShop.Core.Entity;

namespace Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebShopDbContext _ctx;

        public ProductRepository(WebShopDbContext ctx)
        {
            _ctx = ctx;
        }
        public Product CreateProduct(Product product)
        {
            var add = _ctx.Products.Add(product).Entity;
            _ctx.SaveChanges();
            return add;
        }

        public Product DeleteProduct(Product delProduct)
        {
            var deleted = _ctx.Products.Remove(delProduct).Entity;
            _ctx.SaveChanges();
            return deleted;
        }

        public IEnumerable<Product> ReadProducts(Filter filter)
        {
            if (filter == null)
            {
                return _ctx.Products;
            }

            return _ctx.Products.Skip(filter.CurrentPage - 1 * filter.ItemsPrPage);
        }

        public Product ReadById(int id)
        {
            var prod = _ctx.Products.FirstOrDefault(p => p.Id == id);
            return prod;
        }

        public Product UpdateProduct(Product productToUpdate)
        {
            var updated = _ctx.Update(productToUpdate).Entity;
            _ctx.SaveChanges();
            return updated;
        }
    }
}
