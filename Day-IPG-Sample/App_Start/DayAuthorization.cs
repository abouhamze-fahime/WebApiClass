using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Day_IPG_Sample.App_Start
{
    public class DayAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.FirstOrDefault(x => x.Key == "Token").Value?.FirstOrDefault();

            if (token == null)
            {
                throw new Exception("Unauthorized request");
            }
            else
            {
                var principal = TokenManager.GetPrincipal(token);
                if (principal != null)
                {
                    HttpContext.Current.User = principal;

                    string claim = actionContext.ActionDescriptor.GetCustomAttributes<DayClaimAttribute>().FirstOrDefault()?.Title;

                    if (
                        claim == null ||
                        HasAccess(HttpContext.Current.User.Identity.Name, claim))
                        base.OnAuthorization(actionContext);
                    else
                    {
                        throw new Exception("You do not have access");
                    }
                }
                else
                {
                    throw new Exception("Invalid token");
                }
            }
        }

        private bool HasAccess(string username, string claim)
        {
            return false;
        }
    }
}