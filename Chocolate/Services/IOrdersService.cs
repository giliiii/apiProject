using Chocolate.Models;

namespace Chocolate.Services
{
    public interface IOrdersService
    {
        Orders AddOrder(Orders ord);
        dynamic GetOrdersWithProd();
    }
}