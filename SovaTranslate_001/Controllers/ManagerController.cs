using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SovaTranslate_001.Controllers
{

    [CustomAttribute.PageAuthorize(UserRoles = "1")]
    public class ManagerController : Controller
    {
        //
        // GET: /manager/

        public ActionResult Index()
        {
            return View();
        }
       // public ActionResult Orders() {
            
       // }
        public ActionResult UsersList() {
            return View(DataBase.GetAllUsers());
        }
        public ActionResult AddUser() {
            return View("~/Views/Account/Registration.cshtml");
        }
        public ActionResult AddApplication(int userId)
        {
            TempData["userId"] = userId;
            return RedirectToAction("Register", "Application");
        }
        //public ActionResult Statistic() { }

    }
}
