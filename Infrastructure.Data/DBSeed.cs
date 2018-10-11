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
            if (!ctx.Products.Any() && !ctx.Customers.Any() && !ctx.Orders.Any())
            {
                var prod1 = ctx.Products.Add(new Product()
                {
                    Stock = 5,
                    Price = 500,
                    Console = "PS4",
                    Title = "Spooperman",
                    ReleaseDate = DateTime.Now,
                    Image = "https://i.imgur.com/adgPb5G.png",
                    Description = "Play as Spooderbabe in this new game about the wall crawling piece of shit"
                }).Entity;
               var prod2 = ctx.Products.Add(new Product()
                {
                    Stock = 5,
                    Price = 500,
                    Console = "PS4",
                    Title = "God Of War",
                    ReleaseDate = DateTime.Now,
                    Image = "https://i.imgur.com/Jll6NYX.jpg",
                    Description = "God Of War is back with a vengeance in this cashgrab mobile game ported to PS5"
                }).Entity;
                var prod3 = ctx.Products.Add(new Product()
                {
                    Stock = 5,
                    Price = 500,
                    Console = "PS4",
                    Title = "Last of Us",
                    ReleaseDate = DateTime.Now,
                    Image = "https://i.imgur.com/NhQjtMr.jpg",
                    Description = "This game is garbage don't get it"
                }).Entity;

                var cust1 = ctx.Customers.Add(new Customer()
                {
                    Address = "Stormgade 6",
                    Email = "yindoom@hotmail.com",
                    Name = "Bastian",
                    PreferredConsole = "PS4",
                    Password = "pass"
                }).Entity;
                var cust2 = ctx.Customers.Add(new Customer()
                {
                    Address = "Stormgade 6",
                    Email = "fabio@hotmail.com",
                    Name = "Fabio",
                    PreferredConsole = "PC",
                    Password = "pass"
                }).Entity;
                var cust3 = ctx.Customers.Add(new Customer()
                {
                    Address = "Stormgade 6",
                    Email = "hotboy@hotmail.com",
                    Name = "AHotBoy",
                    PreferredConsole = "XBOX1",
                    Password = "pass"
                }).Entity;

                ctx.Orders.Add(new Order()
                {
                    Product = prod1,
                    Customer = cust1,
                    Price = 1000,
                });
                ctx.Orders.Add(new Order()
                {
                    Product = prod2,
                    Customer = cust2,
                    Price = 1000,
                });
                ctx.Orders.Add(new Order()
                {
                    Product = prod3,
                    Customer = cust1,
                    Price = 1000,
                });
                ctx.SaveChanges();
            }


        }
    }
}