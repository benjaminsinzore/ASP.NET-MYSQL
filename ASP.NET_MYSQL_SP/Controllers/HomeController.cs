using Libs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ASP.NET_MYSQL_SP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {

        private readonly SecurityRoute securityRoute = new SecurityRoute();

     

        [HttpGet("GetUserById")]
        public ActionResult<string> GetUserById()
        {
            var res = securityRoute.GetUserById();
            return Ok(securityRoute.GetUserById());
        }
    }
}
