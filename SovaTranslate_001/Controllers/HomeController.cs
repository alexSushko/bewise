using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SovaTranslate_001.CustomAttribute;
using SovaTranslate_001.Models;
namespace SovaTranslate_001.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private sovadb001Entities0 db = new sovadb001Entities0();


        public ActionResult Index()
        {
            ViewBag.CurrentPage = "Home";
            return View();
        }
        public ActionResult AboutUs(){
            ViewBag.CurrentPage = "AboutUs";
            return View();
        }
        public ActionResult Services() {
            ViewBag.CurrentPage = "Services";
            return View();
        }
        public ActionResult Prices() {
            ViewBag.CurrentPage = "Prices";
            return View();
        }

    }
}
