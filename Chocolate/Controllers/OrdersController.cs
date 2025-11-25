using Chocolate.Models;
using Chocolate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Chocolate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController: ControllerBase
    
    {
        private readonly OrdersService OrdersService = new();

        [HttpGet]
        [Route("WithProducts")]
        public IActionResult getProductByCategory()
        {
            return Ok(OrdersService.GetOrdersWithProd());
        }

        [HttpPost]
        public IActionResult AddOrder(Orders ord)
        {
            
            return Ok(OrdersService.AddOrder(ord));
        }
    }
}
