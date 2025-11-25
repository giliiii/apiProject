using Chocolate.Models;
using Chocolate.Repositories;
using Chocolate.DTO;


namespace Chocolate.Services
{
    public class ProductsService
    {
        private readonly ProductsRepository _repository = new();

        public List<ProductWithCategoryDto> GetProductWithCategoryDto()
        {
            return _repository.GetProductWithCategoryDto();
        }
        public dynamic GetProductsWithCategory()
        {
            return _repository.GetProductsWithCategory();
        }

        public List<ProductsDto> productsOrdersDto()
        {
            return _repository.GetOrderProductDto();
        }

        public List<Products> ProductsOrder()
        {
            return _repository.GetOrderProduct();
        }

        public List<Products> GetProductsByCategory(int cid)
        {
            return _repository.GetProductsByCategory(cid);
        }
        public ProductsDto DeleteProductDto(int id)
        {
            return _repository.DeleteProductDto(id);
        }
        public Products DeleteProduct(int id)
        {
            return _repository.DeleteProduct(id);
        }

        public List<Products> AddSumProducts(List<ProductsDto> products)
        {
            return _repository.AddSumProducts(products);
        }
    }
}
