using WebShop.Core.Entity;

namespace Infrastructure.Data
{
    public class DBSeed
    {
        public static void SeedDB(WebShopDbContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var customer0 = ctx.Customers.Add(new Customer() {
                Id = 1,
                Name = "EO",
                Address = "E",
                Email = "O",
                Orders = null,
                PreferredConsole = "PC"
            });
            ctx.SaveChanges();

        }
    }
}