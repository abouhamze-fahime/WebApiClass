using System.Web;
using System.Web.Http;
using Day_IPG_Sample.App_Start;
using Day_IPG_Sample.Models;

namespace Day_IPG_Sample.Controllers
{
    public class AutheticationController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Login(LoginViewModel vm)
        {
            if (vm.UserName == "vahid" && vm.Password == "123")
            {
                HttpContext.Current.Response.Headers.Add("Token", TokenManager.GenerateToken(vm.UserName));
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [DayAuthorize]
        [DayClaim("Day-Security-Common")]
        public void LogOut()
        {

        }
    }
}