using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using WebShop.Core.Entity;

namespace Infrastructure.Data
{
    public class WebShopDbContext : DbContext
    {
     public WebShopDbContext(DbContextOptions<WebShopDbContext> opt) : base(opt)
     {    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasMany(o => o.Products);
            modelBuilder.Entity<Customer>().HasMany(c => c.Orders)
                .WithOne(o => o.Customer).OnDelete(DeleteBehavior.SetNull);
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}