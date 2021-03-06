﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Remotion.Linq.Clauses;
using WebShop.Core;
using WebShop.Core.Domain;
using WebShop.Core.Entity;

namespace Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebShopDbContext _ctx;
        private readonly IOrderRepository _orderRepository;

        public ProductRepository(WebShopDbContext ctx, IOrderRepository orderRepository)
        {
            _ctx = ctx;
            _orderRepository = orderRepository;
        }
        public Product CreateProduct(Product product)
        {
            var add = _ctx.Products.Add(product).Entity;
            _ctx.SaveChanges();
            return add;
        }

        public Product DeleteProduct(Product delProduct)
        {
            _orderRepository.DeleteAllProductOrders(delProduct);
            var deleted = _ctx.Products.Remove(delProduct).Entity;
            _ctx.SaveChanges();
            return deleted;
        }

        public IEnumerable<Product> ReadProducts(Filter filter)
        {
            if (filter.CurrentPage>=1 || filter.ItemsPrPage>=1)
            {
                return _ctx.Products.Skip(filter.CurrentPage - 1 * filter.ItemsPrPage).Take(filter.ItemsPrPage);
            }

            return _ctx.Products;
        }

        public Product ReadById(int id)
        {
            var prod = _ctx.Products.FirstOrDefault(p => p.Id == id);
            return prod;
        }

        public Product UpdateProduct(Product productToUpdate)
        {
            var updated = _ctx.Products.Update(productToUpdate).Entity;
            _ctx.SaveChanges();
            return updated;
        }
    }
}
