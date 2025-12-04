using Chocolate.DTO;
using Chocolate.Models;

namespace Chocolate.Services
{
    public interface IProductsService
    {
        List<Products> AddSumProducts(List<ProductsDto> products);
        Products DeleteProduct(int id);
        ProductsDto DeleteProductDto(int id);
        List<Products> GetProductsByCategory(int cid);
        dynamic GetProductsWithCategory();
        List<ProductWithCategoryDto> GetProductWithCategoryDto();
        List<Products> ProductsOrder();
        List<ProductsDto> productsOrdersDto();
    }
}