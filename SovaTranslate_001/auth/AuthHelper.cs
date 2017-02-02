using System;
using System.Web;
using SovaTranslate_001.Models;
namespace SovaTranslate_001.auth
{
    
    public static class AuthHelper
    {
        
        public static void LogInUser(HttpContextBase httpContext, string cookies)
        {
            var cookie = new HttpCookie("__AUTH") { Value = cookies, Expires = DateTime.Now.AddYears(1)};

            httpContext.Response.Cookies.Add(cookie);
        }

        public static void LogOffUser(HttpContextBase httpContext)
        {
            if (httpContext.Request.Cookies["__AUTH"] != null)
            {
                var cookie = new HttpCookie("__AUTH") { Expires = DateTime.Now.AddDays(-1) };
                
                httpContext.Response.Cookies.Add(cookie);
            }
        }
        public static user GetUser(HttpContextBase httpContext)
        {
            sovadb001Entities0 db = new sovadb001Entities0();
            var authCookie = httpContext.Request.Cookies["__AUTH"];

            if (authCookie != null)
            {
                user user = DataBase.GetUserByCookeis(authCookie.Value);

                return user;
            }

            return null;
        }

        public static user GetUser(HttpContext httpContext)
        {
            sovadb001Entities0 db = new sovadb001Entities0();
            var authCookie = httpContext.Request.Cookies["__AUTH"];
            
            if (authCookie != null)
            {
                user user = DataBase.GetUserByCookeis(authCookie.Value); 

                return user;
            }

            return null;
        }

        public static bool IsAuthenticated(HttpContext httpContext) 
        {
            var authCookie = httpContext.Request.Cookies["__AUTH"];

            if (authCookie != null)
            {
                user user = DataBase.GetUserByCookeis(authCookie.Value);

                return user != null;
            }

            return false;
        }
    }
}