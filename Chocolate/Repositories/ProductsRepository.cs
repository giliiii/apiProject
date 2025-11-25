using Chocolate.Data;
using Chocolate.DTO;
using Chocolate.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Frozen;
using System.Data;
//using Microsoft.EntityFrameworkCore;

namespace Chocolate.Repositories

{
    public class ProductsRepository
    {
        ShopContext context = ShopContextFactory.CreateContext();

        public List<ProductWithCategoryDto> GetProductWithCategoryDto()
        {
            var product = context.Products
                .Where(a => a.IsDeleted != true)
                .Select(p => new ProductWithCategoryDto
                {
                    Name = p.Name,
                    Category = p.Category.Name,
                })
                .ToList();
            return product;
        }

        public dynamic GetProductsWithCategory()
        {
            var products = context.Products
                .Include(p => p.Category)
                .Where(a => a.IsDeleted != true)
                .Select(a => new
                {
                    a.Name,
                    category = a.Category.Name
                }).ToList();
            return products;
        }

        public List<ProductsDto> GetOrderProductDto()
        {
            var products = context.Products.Where(a => a.IsDeleted != true)
                .Select(b => new ProductsDto
                {
                    Name = b.Name,
                    Description = b.Description,
                    cost = b.Cost,
                    CategoryId = b.CategoryId,
                })
                .OrderBy(b => b.Name)
            .ToList();
            return products;
        }

        public List<Products> GetOrderProduct()
        {
            var products = context.Products
                .Where(a => a.IsDeleted != true)
                .OrderBy(a => a.Name)
                .ToList();
            return products;
        }

        public List<Products> GetProductsByCategory(int cid)
        {
            var products = context.Products
                .Where(c => (c.Category.Id == cid) && (c.IsDeleted != true))
                .ToList();
            return products;
        }

        public ProductsDto DeleteProductDto(int id)
        {
            var product = context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductsDto
                {
                    Name = p.Name,
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    IsDelited = p.IsDeleted,
                    cost = p.Cost,
                }).ToList();
            product[0].IsDelited = true;
            context.Update(product[0]);
            return product[0];
        }
        public Products DeleteProduct(int id)
        {
            var product = context.Products
                .Where(p => p.Id == id).ToList();
            product[0].IsDeleted = true;
            context.Update(product[0]);
            return product[0];
        }

        public List<Products> AddSumProducts(List<ProductsDto> products)
        {
            List <Products> p= new();
            for(int i=0;i<products.Count;i++)
            {
                Products tmp = new();
                tmp.Name = products[i].Name;
                tmp.Description = products[i].Description;
                tmp.Cost = products[i].cost;
                tmp.CategoryId = products[i].CategoryId;
                tmp.IsDeleted = products[i].IsDelited;
                tmp.Category = null;
                p.Add(tmp);
            }
            context.Products.AddRange(p);
            context.SaveChanges();
            var product2 = context.Products.ToList();
            return product2;
        }

        public int CreateProductWithProc(ProductsDto prod)
        {
            var output = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            var parameters = new[]
            {
                output,
                new SqlParameter("@Name",prod.Name),
                new SqlParameter("@Desc",prod.Description),
                new SqlParameter("@Cost",prod.cost),
                new SqlParameter("@IsDeleted",prod.IsDelited),
                new SqlParameter("@CategoryId",prod.CategoryId)
            };

            context.Database.ExecuteSqlRaw(
            "exec addProductProc @id OUTPUT,@Name,@Desc,@Cost,@IsDeleted,@CategoryId",
            parameters
                );
            int newProdId = (int)output.Value;
            return newProdId;
        }
        public int tran()
        {
              using var transaction = context.Database.BeginTransaction();
            try
            { 
                var output = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };
        
                // First procedure
                var parameters = new[]
              {
                output,
                new SqlParameter("@Name","pati"),
                new SqlParameter("@Desc","pati desc"),
                new SqlParameter("@Cost",40),
                new SqlParameter("@IsDeleted",false),
                new SqlParameter("@CategoryId",1)
            };

                context.Database.ExecuteSqlRaw(
                "exec addProductProc @id OUTPUT,@Name,@Desc,@Cost,@IsDeleted,@CategoryId",
                parameters
                    );
                // Second procedure
                var parameters2 = new[]
              {
                output,
                new SqlParameter("@Name","pati2"),
                new SqlParameter("@Desc","pati2 desc"),
                new SqlParameter("@Cost",35),
                new SqlParameter("@IsDeleted",true),
                new SqlParameter("@CategoryId",2)
            };

                context.Database.ExecuteSqlRaw(
                "exec addProductProc @id OUTPUT,@Name,@Desc,@Cost,@IsDeleted,@CategoryId",
                parameters2
                    );
                transaction.Commit();
                return (1);
            }
            catch
            {
                transaction.Rollback();
                return(0);
            }

        }
    }
}

