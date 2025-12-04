using Chocolate.Models;
using Chocolate.Repositories;

namespace Chocolate.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly OrdersRepository _repository = new();
        public dynamic GetOrdersWithProd()
        {
            return _repository.GetOrdersWithProducts();
        }

        public Orders AddOrder(Orders ord)
        {
            return _repository.AddOrder(ord);
        }
    }
}
