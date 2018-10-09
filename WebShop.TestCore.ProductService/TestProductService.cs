using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Moq;
using WebShop.Core.Domain;
using WebShop.Core.Entity;
using WebShop.Core.Services.Implementation;
using Xunit;

namespace WebShop.TestCore.ProductService
{
    public class TestProductService
    {
        [Fact]
        public void TestInitSize()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Assert.True(service.GetAllProducts().Count == 0);
        }
        
        [Fact]
        public void AddProduct()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Assert.True(service.GetAllProducts().Count == 0);
            var prod1 = new Product()
            {
                Id = 0,
                Console = "PS4",
                Price = 500,
                Stock = 5,
                Title = "Spoodermoobs",
                ReleaseDate = DateTime.Now
            };
            service.CreateProduct(prod1);
            Assert.True(service.GetProductById(0) == prod1);
        }

        [Fact]
        public void TestDelete()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Assert.True(service.GetAllProducts().Count == 0);
            var prod1 = new Product()
            {
                Id = 0,
                Console = "PS4",
                Price = 500,
                Stock = 5,
                Title = "Spoodermoobs",
                ReleaseDate = DateTime.Now
            };
            service.CreateProduct(prod1);
            Assert.True(service.GetProductById(0) == prod1);
            service.DeleteProduct(0);
            Assert.True(service.GetAllProducts().Count == 0);
        }

        [Fact]
        public void TestSell()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Assert.True(service.GetAllProducts().Count == 0);
            var prod1 = new Product()
            {
                Id = 0,
                Console = "PS4",
                Price = 500,
                Stock = 5,
                Title = "Spoodermoobs",
                ReleaseDate = DateTime.Now
            };
            service.CreateProduct(prod1);
            service.SellOneProduct(0);
            Assert.True(service.GetProductById(0).Stock == 4);
        }

        [Fact]
        public void TestBuy()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Assert.True(service.GetAllProducts().Count == 0);
            var prod1 = new Product()
            {
                Id = 0,
                Console = "PS4",
                Price = 500,
                Stock = 5,
                Title = "Spoodermoobs",
                ReleaseDate = DateTime.Now
            };
            service.CreateProduct(prod1);
            service.AddToStock(0, 50);
            Assert.True(service.GetProductById(0).Stock == 55);
        }

        [Fact]
        public void TestAddProductWithNoName()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Assert.True(service.GetAllProducts().Count == 0);
            var prod1 = new Product()
            {
                Id = 0,
                Console = "PS4",
                Price = 500,
                Stock = 5,
                ReleaseDate = DateTime.Now
            };
            Exception ex = Assert.Throws<InvalidDataException>(() => 
                service.CreateProduct(prod1));
            Assert.Equal("Product must have a title.", ex.Message);
        }

        [Fact]
        public void TestAddProductWithNoConsole()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Assert.True(service.GetAllProducts().Count == 0);
            var prod1 = new Product()
            {
                Id = 0,
                Title = "Spooperman",
                Price = 500,
                Stock = 5,
                ReleaseDate = DateTime.Now
            };
            Exception ex = Assert.Throws<InvalidDataException>(() => 
                service.CreateProduct(prod1));
            Assert.Equal("Product must be for a console.", ex.Message);
        }

        [Fact]
        public void TestAddProductWithNoStock()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Assert.True(service.GetAllProducts().Count == 0);
            var prod1 = new Product()
            {
                Id = 0,
                Console = "PS4",
                Price = 500,
                Title = "Spoodermoobs",
                ReleaseDate = DateTime.Now
            };
            service.CreateProduct(prod1);
            Assert.Equal(service.GetProductById(0).Stock, 0);
        }

        [Fact]
        public void TestAddProductWithNoPrice()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Assert.True(service.GetAllProducts().Count == 0);
            var prod1 = new Product()
            {
                Id = 0,
                Console = "PS4",
                Stock = 5,
                Title = "Spoodermoobs",
                ReleaseDate = DateTime.Now
            };
            service.CreateProduct(prod1);
            Assert.Equal(service.GetProductById(0).Price, 0);
        }
        
        [Fact]
        public void TestAddProductWithNegativePrice()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Assert.True(service.GetAllProducts().Count == 0);
            var prod1 = new Product()
            {
                Id = 0,
                Console = "PS4",
                Stock = 5,
                Price = -5,
                Title = "Spoodermoobs",
                ReleaseDate = DateTime.Now
            };
            service.CreateProduct(prod1);
            Assert.Equal(service.GetProductById(0).Price, 0);
        }

        [Fact]
        public void TestAddProductWithNoRelease()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Assert.True(service.GetAllProducts().Count == 0);
            var prod1 = new Product()
            {
                Id = 0,
                Console = "PS4",
                Price = 500,
                Stock = 5,
                Title = "Spoodermoobs",
            };
            Exception ex = Assert.Throws<InvalidDataException>(() => 
                service.CreateProduct(prod1));
            Assert.Equal("Product must have a release date.", ex.Message);
        }
        
        [Fact]
        public void TestUpdateProductWithWrongId()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Assert.True(service.GetAllProducts().Count == 0);
            var prod1 = new Product()
            {
                Id = 0,
                Console = "PS4",
                Price = 500,
                Stock = 5,
                Title = "Spoodermoobs",
                ReleaseDate = DateTime.Now
            };
            service.CreateProduct(prod1);
            
            var prod2 = new Product()
            {
                Console = "PS4",
                Price = 500,
                Stock = 5,
                Title = "Spoodermoobs",
                ReleaseDate = DateTime.Now
            };
            
            Exception ex = Assert.Throws<InvalidDataException>(() => 
                service.UpdateProduct(1, prod2));
            Assert.Equal("Product Id does not exist.", ex.Message);
        }

        [Fact]
        public void TestGetUnexistingProduct()
        {
            var service = new Core.Services.Implementation.ProductService(new TestProdRepo());
            Exception ex = Assert.Throws<InvalidDataException>(() => 
                service.GetProductById(1));
            Assert.Equal("Product does not exist.", ex.Message);
        }
    }

    public class TestProdRepo : IProductRepository
    {
        IEnumerable<Product> products = new List<Product>();
        public Product CreateProduct(Product product)
        {
            var list = products.ToList();
            list.Add(product);
            products = list;
            return product;
        }

        public IEnumerable<Product> ReadProducts(Filter filter = null)
        {
            return products;
        }

        public Product ReadById(int id)
        {
            foreach (var prod in products)
            {
                if (prod.Id == id)
                {
                    return prod;
                }
            }
            return null;
        }

        public Product UpdateProduct(Product productToUpdate)
        {
            Product[] arr = products.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Id == productToUpdate.Id)
                {
                    arr[i] = productToUpdate;
                }
            }
            products = arr.ToList();
            return productToUpdate;
        }

        public Product DeleteProduct(Product delProduct)
        {
            Product temp = null;
            foreach (var product in products)
            {
                if (product.Id == delProduct.Id)
                    temp = product;
            }

            if (temp != null)
            {
                var list = products.ToList();
                list.Remove(temp);
                products = list;
            }

            return delProduct;
        }
    }
}