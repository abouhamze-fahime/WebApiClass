using System;
using System.Data;
using System.Data.SqlClient;
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
            //ADO.NET  ===> EF
            if (ModelState.IsValid == false || string.IsNullOrEmpty(vm.UserName.Trim()) || string.IsNullOrEmpty(vm.Password.Trim()))
            {
                return BadRequest("username or password is null or empty");
            }

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=.\SQL2019;Database=WebApiClass;Integrated Security = true";

            if (connection.State != ConnectionState.Closed)
                connection.Close();

            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = $"SELECT TOP 1 id FROM Account.tblUsers WHERE Username = '{vm.UserName}' AND Password = '{Hash.GetHash(vm.Password)}'";
            command.Connection = connection;

            SqlDataReader result = command.ExecuteReader();
            if (result.HasRows)
            {
                result.Close();
                result.Dispose();

                string token = TokenManager.GenerateToken(vm.UserName);
                HttpContext.Current.Response.Headers.Add("Token", token);

                command.CommandText = $"INSERT INTO Account.tblActiveSessions VALUES('{vm.UserName}','{token}')";
                command.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();
                command.Dispose();

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
        public IHttpActionResult LogOut()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=.\SQL2019;Database=WebApiClass;Integrated Security = true";

            if (connection.State != ConnectionState.Closed)
                connection.Close();

            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText =
                $"DELETE FROM Account.tblActiveSessions WHERE Username='{HttpContext.Current.User.Identity.Name}'";
            command.Connection = connection;

            var affectedRowCount = command.ExecuteNonQuery();
            if (affectedRowCount > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Usre does not have any active session");
            }
        }
    }
}