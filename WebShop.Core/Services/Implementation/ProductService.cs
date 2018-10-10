﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using WebShop.Core.Domain;
using WebShop.Core.Entity;
using WebShop.Core.Service;

namespace WebShop.Core.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public Product CreateProduct(Product product)
        {
            if (product.Price == null || product.Price <= 0)
            {
                product.Price = 0;
            }

            if (String.IsNullOrEmpty(product.Console))
            {
                throw new InvalidDataException("Product must be for a console.");
            }

            if (String.IsNullOrEmpty(product.Title))
            {
                throw new InvalidDataException("Product must have a title.");
            }

            if (product.ReleaseDate.Equals(DateTime.MinValue))
            {
                throw new InvalidDataException("Product must have a release date.");
            }
            return _productRepo.CreateProduct(product);
        }

        public Product SellOneProduct(int i)
        {
            var sell = _productRepo.ReadById(i);
            sell.Stock--;
            return _productRepo.UpdateProduct(sell);
        }

        public Product AddToStock(int id, int stock)
        {
            var stockAdd = _productRepo.ReadById(id);
            stockAdd.Stock += stock;
            return _productRepo.UpdateProduct(stockAdd);
        }

        public Product DeleteProduct(int idProduct)
        {
            var deleted = _productRepo.ReadById(idProduct);
            return _productRepo.DeleteProduct(deleted);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepo.ReadProducts().ToList();
        }

        public Product GetProductById(int id)
        {
            var prod = _productRepo.ReadById(id);
            if (prod == null)
            {
                throw new InvalidDataException("Product does not exist.");
            }
                return _productRepo.ReadById(id);
        }

        public Product UpdateProduct(int id, Product updateProd)
        {
            updateProd.Id = id;
            return _productRepo.UpdateProduct(updateProd);
        }
    }
}
