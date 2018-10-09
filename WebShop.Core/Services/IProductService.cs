using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;

namespace WebShop.Core.Service
{
    public interface IProductService
    {
        Product CreateProduct (Product product);
        List<Product> GetAllProducts();
        Product UpdateProduct(Product productToUpdate);
        Product DeleteProduct(int idProduct);
    }
}
