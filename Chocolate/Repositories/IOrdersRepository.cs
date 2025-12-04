using Chocolate.Models;

namespace Chocolate.Repositories
{
    public interface IOrdersRepository
    {
        Orders AddOrder(Orders ord);
        dynamic GetOrdersWithProducts();
    }
}