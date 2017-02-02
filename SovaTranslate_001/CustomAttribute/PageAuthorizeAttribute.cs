using System.Linq;
using System.Web;
using System.Web.Mvc;
using SovaTranslate_001.Models;
namespace SovaTranslate_001.CustomAttribute
{
    public class PageAuthorizeAttribute : AuthorizeAttribute
    {
        public string UserRoles { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authCooke = httpContext.Request.Cookies["__AUTH"];

            if (authCooke != null)
            {
                user us = DataBase.GetUserByCookeis(authCooke.Value);

                return UserRoles.Split(',').Any(r => r.Trim() == us.roleid.ToString()); ;
            }

            return false;
        }
    }
}