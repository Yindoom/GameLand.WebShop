using System;
using System.Collections.Generic;
using System.Text;
using WebShop.Core.Entity;

namespace WebShop.Core.Domain
{
    public interface IProductRepository
    {

        Product CreateProduct(Product product);
        Product ReadProduct(int id);
        Product UpdateProduct(Product productToUpdate);
        Product DeleteProduct(int idProduct);
    }
}
