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
            var token = actionContext.Request.Headers.FirstOrDefault(x => x.Key == "Authentication").Value?.FirstOrDefault();

            if (token == null)
            {
                throw new Exception("Unauthorized request");
            }

            var principal = TokenManager.GetPrincipal(token);
            if (principal != null)
            {
                HttpContext.Current.User = principal;

                using (var ctx = new DayContext.DayContext())
                {
                    if (!ctx.ActiveSessions.Any(x =>
                        x.NationalCode == HttpContext.Current.User.Identity.Name &&
                        x.IP == HttpContext.Current.Request.UserHostAddress &&
                        x.Token == token))
                    {
                        throw new Exception("Invalid token");
                    }
                }

                base.OnAuthorization(actionContext);
            }
            else
            {
                throw new Exception("Invalid token");
            }
        }
    }
}