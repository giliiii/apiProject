using Chocolate.Data;
using Microsoft.EntityFrameworkCore;
using Chocolate.Models;
using Chocolate.DTO;


namespace Chocolate.Repositories
{
    public class OrdersRepository
    {
        ShopContext context = ShopContextFactory.CreateContext();

        public dynamic GetOrdersWithProducts()
        {
            var order = context.Orders
                    .Include(x => x.ProductList)
                   
                    .Select(a => new
                    {
                        a.Id,
                        a.UserId,
                        a.User,
                        Category = a.ProductList.Where(p => p.IsDeleted!=true).Select(c => c.Name)
                    }).ToList();


            return order;

        }

        public Orders AddOrder(Orders ord)
        {
            var order = context.Orders.Add(ord);
            context.SaveChanges();
            return ord;
              
        }
    }
}
