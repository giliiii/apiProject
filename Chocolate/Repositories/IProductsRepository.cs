using Chocolate.DTO;
using Chocolate.Models;

namespace Chocolate.Repositories
{
    public interface IProductsRepository
    {
        List<Products> AddSumProducts(List<ProductsDto> products);
        int CreateProductWithProc(ProductsDto prod);
        Products DeleteProduct(int id);
        ProductsDto DeleteProductDto(int id);
        List<Products> GetOrderProduct();
        List<ProductsDto> GetOrderProductDto();
        List<Products> GetProductsByCategory(int cid);
        dynamic GetProductsWithCategory();
        List<ProductWithCategoryDto> GetProductWithCategoryDto();
        int tran();
    }
}