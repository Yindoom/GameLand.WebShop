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
        Product GetProductById(int id);
        Product UpdateProduct(int id, Product productToUpdate);
        Product SellOneProduct(int i);
        Product AddToStock(int id, int stock);
        Product DeleteProduct(int idProduct);


    }
}
