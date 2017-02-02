using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SovaTranslate_001.Models;

using Puma.Net;


namespace SovaTranslate_001.Controllers
{
    public class UserController : Controller
    {
        //
        
        // GET: /User/
        
        public ActionResult Orders()
        {
            user u = auth.AuthHelper.GetUser(HttpContext);
            var i = DataBase.GetUserOrders(u);
            return View(i);
            
        }
        
        public ActionResult Index()
        {
            return View();
        }

    }
}
