using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using WebShop.Core.Entity;

namespace Infrastructure.Data
{
    public class DBSeed
    {
        public static void SeedDB(WebShopDbContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            
            if (!ctx.Products.Any())
            {
                ctx.Products.Add(new Product()
                {
                    Stock = 5,
                    Price = 500,
                    Console = "PS4",
                    Title = "Spooperman",
                    ReleaseDate = DateTime.Now
                });
                ctx.Products.Add(new Product()
                {
                    Stock = 5,
                    Price = 500,
                    Console = "PS4",
                    Title = "God Of War",
                    ReleaseDate = DateTime.Now
                });
                ctx.Products.Add(new Product()
                {
                    Stock = 5,
                    Price = 500,
                    Console = "PS4",
                    Title = "Last of Us",
                    ReleaseDate = DateTime.Now
                });
            }

            if (!ctx.Customers.Any())
            {
                ctx.Customers.Add(new Customer()
                {
                    Address = "Stormgade 6",
                    Email = "yindoom@hotmail.com",
                    Name = "Bastian",
                    LastName = "Bønkel",
                    PhoneNumber = 2394234,
                    PreferredConsole = "PS4"
                });
                ctx.Customers.Add(new Customer()
                {
                    Address = "Stormgade 6",
                    Email = "fabio@hotmail.com",
                    Name = "Fabio",
                    LastName = "PortugueseLastName",
                    PreferredConsole = "PC"
                });
                ctx.Customers.Add(new Customer()
                {
                    Address = "Stormgade 6",
                    Email = "hotboy@hotmail.com",
                    Name = "AHotBoy",
                    LastName = "HostLastName",
                    PreferredConsole = "XBOX69"
                });
            }

            /*
             if(!ctx.Orders.Any())
             {
             ctx.Orders.Add(new Order()
             {
                 products = new List<Product>()
                 {
                     new Product() {Id = 0},
                     new Product() {Id = 1}
                 },
                 customer = new Customer() {Id = 0},
                 Price = 1000,
             });
             ctx.Orders.Add(new Order()
             {
                 products = new List<Product>()
                 {
                     new Product() {Id = 0},
                     new Product() {Id = 2}
                 },
                 customer = new Customer() {Id = 1},
                 Price = 1000,
             });
             ctx.Orders.Add(new Order()
             {
                 products = new List<Product>()
                 {
                     new Product() {Id = 2},
                     new Product() {Id = 1}
                 },
                 customer = new Customer() {Id = 2},
                 Price = 1000,
             });
             }*/
                ctx.SaveChanges();
            }
        }
    }
