using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using Day_IPG_Sample.App_Start;
using Day_IPG_Sample.DayContext.Models.Account;
using Day_IPG_Sample.Models;

namespace Day_IPG_Sample.Controllers
{
    public class AutheticationController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid == false || string.IsNullOrEmpty(vm.NationalCode.Trim()) || string.IsNullOrEmpty(vm.MobileNumber.Trim()))
            {
                return BadRequest("national code or mobile number is null or empty");
            }

            using (DayContext.DayContext ctx = new DayContext.DayContext())
            {
                //string hashedPassword = Hash.GetHash(vm.Password);

                if (ctx.Users.Any(x => x.NationalCode == vm.NationalCode && x.MobileNumber == vm.MobileNumber))
                {
                    var rndCode = new Random().Next(111111, 999999);

                    ctx.OTPRequests.Add(new OTPRequests()
                    {
                        NationalCode = vm.NationalCode,
                        Code = rndCode
                    });

                    //SEND Code as SMS

                    return Ok();
                }
                else
                {
                    //user does not exist
                    return NotFound();
                }
            }

            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=.\SQL2019;Database=WebApiClass;Integrated Security = true";

            //if (connection.State != ConnectionState.Closed)
            //    connection.Close();

            //connection.Open();

            //SqlCommand command = new SqlCommand();
            //command.CommandText = $"SELECT TOP 1 id FROM Account.tblUsers WHERE Username = '{vm.UserName}' AND Password = '{Hash.GetHash(vm.Password)}'";
            //command.Connection = connection;

            //SqlDataReader result = command.ExecuteReader();
            //if (result.HasRows)
            //{
            //    result.Close();
            //    result.Dispose();

            //    string token = TokenManager.GenerateToken(vm.UserName);
            //    HttpContext.Current.Response.Headers.Add("Token", token);

            //    command.CommandText = $"INSERT INTO Account.tblActiveSessions VALUES('{vm.UserName}','{token}')";
            //    command.ExecuteNonQuery();

            //    connection.Close();
            //    connection.Dispose();
            //    command.Dispose();

            //    return Ok();
            //}
            //else
            //{
            //    return NotFound();
            //}
        }

        [HttpPost]
        [Route("api/authentication/verify-code")]
        [AllowAnonymous]
        public IHttpActionResult VerifyCode(OTPViewModel vm)
        {
            if (ModelState.IsValid == false || string.IsNullOrEmpty(vm.NationalCode.Trim()))
            {
                return BadRequest("national code or code is null or empty");
            }

            using (DayContext.DayContext ctx = new DayContext.DayContext())
            {
                if (ctx.OTPRequests.Any(x => x.NationalCode == vm.NationalCode && x.Code == vm.Code))
                {
                    return Ok();
                }
                else
                {
                    //user does not exist
                    return NotFound();
                }
            }
        }

        //[HttpPut]
        //[DayAuthorize]
        //[DayClaim("Day-Security-Common")]
        //public IHttpActionResult LogOut()
        //{
        //    using (DayContext.DayContext ctx = new DayContext.DayContext())
        //    {
        //        //LINQ
        //        var userId = ctx.Users.FirstOrDefault(x => x.Username == HttpContext.Current.User.Identity.Name)?.Id;

        //        ////select username from activesessions join users on userid = user.id
        //        //var sss = ctx.ActiveSessions.Join(
        //        //    ctx.Users,
        //        //    session => session.UserId,
        //        //    user => user.Id,
        //        //    (session, user) => new
        //        //    {
        //        //        Username = user.Username,
        //        //        Token = session.Token
        //        //    }).Where(x => x.Username == HttpContext.Current.User.Identity.Name).ToList();

        //        var sessions = ctx.ActiveSessions.Where(x => x.UserId == userId).ToList();
        //        if (sessions.Count == 0)
        //        {
        //            return BadRequest("Usre does not have any active session");
        //        }
        //        else
        //        {
        //            ctx.ActiveSessions.RemoveRange(sessions);

        //            ctx.SaveChanges();
        //            return Ok();
        //        }
        //    }
        //    //SqlConnection connection = new SqlConnection();
        //    //connection.ConnectionString = @"Server=.\SQL2019;Database=WebApiClass;Integrated Security = true";

        //    //if (connection.State != ConnectionState.Closed)
        //    //    connection.Close();

        //    //connection.Open();

        //    //SqlCommand command = new SqlCommand();
        //    //command.CommandText =
        //    //    $"DELETE FROM Account.tblActiveSessions WHERE Username='{HttpContext.Current.User.Identity.Name}'";
        //    //command.Connection = connection;

        //    //var affectedRowCount = command.ExecuteNonQuery();
        //    //if (affectedRowCount > 0)
        //    //{
        //    //    return Ok();
        //    //}
        //    //else
        //    //{
        //    //    return BadRequest("Usre does not have any active session");
        //    //}
        //}
    }
}