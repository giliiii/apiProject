using Microsoft.EntityFrameworkCore;

namespace Chocolate.Data
{
    public class ShopContextFactory
    {
        private const string ConnectionString = "Server=Srv2\\pupils;DataBase=ShopDemo0583255125;" +
            "Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;";

        public static ShopContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new ShopContext(optionsBuilder.Options);
        }
    }
}
