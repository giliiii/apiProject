using Chocolate.DTO;
using Chocolate.Models;
using Chocolate.Repositories;
using Chocolate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Chocolate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController:ControllerBase
    {

        private readonly IProductsRepository _repository ;

        private readonly IProductsService productsService;

        public ProductsController(IProductsService productService, IProductsRepository productRepository)
        {
            productsService = productService;
            _repository = productRepository;
        }

        public List<Products> productsList = new List<Products>()
        {
            new Products (){ Id = 1,Name="שוקולד בלגי",Cost=17 },
             new Products (){ Id = 2,Name="שוקולד שוויצרי",Cost=20 }
        };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(productsList);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Products prod)
        {
            try
            {
                productsList.Add(prod);
                
                    return Ok(productsList);
              
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }

        }

        [HttpPost]
        [Route ("tran")]
        public IActionResult CreateTwoProductWithTran()
        {
            try
            {
                int res = _repository.tran();
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed CreareProduct", ex);
                return BadRequest("product not create");
            }
        }



        [HttpPost]
        [Route ("withProc")]
        public IActionResult CreateProductWithProc([FromBody] ProductsDto prod)
        {
            try
            {
                int res = _repository.CreateProductWithProc(prod);
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine("failed CreareProduct",ex);
                return BadRequest("product not create");  
            }
        }

        [HttpPost]
        [Route("many")]
        public IActionResult AddSumProducts(List<ProductsDto> prod)
        {
            return Ok(productsService.AddSumProducts(prod));
        }


        [HttpGet("{id}")]
        public IActionResult getProductById(int id)
        {
            Products? prod=productsList.Find(x => x.Id == id);
            if(prod != null)
                return Ok(prod);
            else return BadRequest("not found");
        }

        [HttpGet]
        [Route("ByCategory")]
        public IActionResult getProductByCategory(int id)
        {
            return Ok(productsService.GetProductsByCategory(id));
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult getProductWithCategory()
        {
            return Ok(productsService.GetProductWithCategoryDto());
        }

        [HttpGet]
        [Route("GetOrder")]
        public IActionResult GetOrderProduct()
        {
            return Ok(productsService.productsOrdersDto());
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Products prod)
        {
            Products? prod2 = productsList.Find(x => x.Id == prod.Id);
            if (prod2 != null)
            {
                prod2.Id = prod.Id;
                prod2.Name = prod.Name;
                prod2.Cost = prod.Cost;
                prod2.Description = prod.Description;
                prod2.Category = prod.Category;
  
                return Ok(productsList);
            }
            else return BadRequest("not found");

        }

        [HttpPut]
        [Route("delete")]
        public IActionResult DeleteProduct(int id) { 
            return Ok(productsService.DeleteProductDto(id));
        }

        [HttpGet]
        [Route("pagination")]
        public IActionResult GetPagination([FromQuery] int page = 1, [FromQuery] int size = 2)
        {
            var pageData = productsList.
                Skip((page - 1) * size)
                .Take(size)
                .ToList();
            return Ok(pageData);
        }
    }
}
