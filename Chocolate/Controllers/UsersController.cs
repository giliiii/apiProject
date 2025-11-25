using Chocolate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Chocolate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public List<Users> usersList = new List<Users>()
        {
            new Users (){ Id = 1,Name="גילי"},
             new Users (){ Id = 2,Name="אילה"}
        };

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(usersList);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] Users user)
        {
            try
            {
                Users? s = usersList.Find(us => user.Name == us.Name);
                if (s == null)
                {
                    usersList.Add(user);
                    return Ok(usersList);
                }
                else
                { return BadRequest("exist"); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }

        }

     


    }
}
