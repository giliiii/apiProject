using Microsoft.EntityFrameworkCore;
using Chocolate.Models;

namespace Chocolate.Data
{
    public class ShopContext:DbContext

    {
        public ShopContext(DbContextOptions<ShopContext>options):base(options) { }
        public DbSet<Categories> Categories=> Set<Categories>();
        public DbSet<Products> Products=> Set<Products>();
        public DbSet<Users> Users=> Set<Users>();
        public DbSet<Orders> Orders => Set<Orders>();
    }
}
