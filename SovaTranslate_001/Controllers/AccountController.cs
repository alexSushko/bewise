using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SovaTranslate_001.CustomAttribute;
using SovaTranslate_001.Models;
namespace SovaTranslate_001.Controllers
{
    public class AccountController : Controller
    {
        private sovadb001Entities0 db = new sovadb001Entities0();
        [HttpGet]
        public ActionResult Registration()
        {
            //registration us = new registration();
            return View();
        }
        //[PageAuthorize(UserRoles="0")]
        //public ActionResult User()
        //{
        //     user us = DataBase.GetUser(
        //               auth.SecurityHelper.Hash(u.password));
        //     if (us != null)
        //     {
        //         //registration us = new registration();
        //         return View(us);
        //     }
        //     else { }
        //}
        [HttpPost]
        public ActionResult Registration(registration u)
        {
            if (ModelState.IsValid)
            {
                user us = new user();

                us.email = u.email.ToString().Trim();
                us.name = u.name.ToString().Trim();
                us.password = auth.SecurityHelper.Hash(u.password);
                us.cookies = Guid.NewGuid().ToString();
                

                db.users.Add(us);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            //ViewBag.Title = (ex.ToString());

            return View(u);
        }
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult LogOff()
        {
            auth.AuthHelper.LogOffUser(HttpContext);

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Login(AuthModel u)
        {
            if (ModelState.IsValid)
            {
                user us = DataBase.GetUser(u.email,
                       auth.SecurityHelper.Hash(u.password));
                if (us != null)
                {
                    auth.AuthHelper.LogInUser(HttpContext, us.cookies);

                    //switch (us.roleid)
                    //{
                    //    case 2:
                    //        return RedirectToAction("Admin", "Admin");
                    //    case 0:
                    //        return RedirectToAction("UserAccount", "User");
                    //}
                }
                else { u.isError = true; return View(u); }
                return RedirectToAction("Index", "Home");
            }
            else { u.isError = false; return View(u); }
        }
        public ActionResult Profile()
        {
            user u = auth.AuthHelper.GetUser(HttpContext);
            if (u != null)
            {
                return View(u);
            }
            else
                return RedirectToAction("Registration", "Account");
        }
        public ActionResult ProfileUser(int id)
        {
            user u = DataBase.GetUser(id);
            if (u != null)
            {
                return View(u);
            }
            else
                return RedirectToAction("Profile", "Account");
        }
        [HttpGet]
        public ActionResult Edit() { 
             user u = auth.AuthHelper.GetUser(HttpContext);
             if (u != null)
             {
                 return View(u);
             }
             else return RedirectToAction("Registration", "Account");
        }
        [CustomAttribute.PageAuthorize(UserRoles = "1,3")]
        [HttpGet]
        public ActionResult EditCustomProfile(int IdUser)
        {

            user u =DataBase.GetUser(IdUser);
            if (u != null)
            {
                return View(u);
            }
            else return RedirectToAction("Profile", "Account");
        }
        [HttpPost]
        public ActionResult EditCustomProfile(user u)
        {
            if (ModelState.IsValid != false)
            {
                 DataBase.UpdateUser(u);
                return RedirectToAction("Profile", "Account");
            }
            else
                return View(u);
        }
        [HttpPost]
        public ActionResult Edit(user u)
        {
            if (ModelState.IsValid != false)
            {
                if(u.Id==auth.AuthHelper.GetUser(HttpContext).Id||auth.AuthHelper.GetUser(HttpContext).Id==1||auth.AuthHelper.GetUser(HttpContext).Id==2||auth.AuthHelper.GetUser(HttpContext).Id==3)
                DataBase.UpdateUser(u,HttpContext);
                return RedirectToAction("Profile", "Account");
            }
            else
                return View(u);
        }
        public ActionResult Index()
        {
            switch (auth.AuthHelper.GetUser(HttpContext).roleid) {
                case 0: return RedirectToAction("Index", "User");
                case 1: return RedirectToAction("Index", "Manager");
                case 2: return RedirectToAction("Index", "Operator");
                case 3: return RedirectToAction("Index", "Admin");
                default: return View();
            }

        }

    }
}
