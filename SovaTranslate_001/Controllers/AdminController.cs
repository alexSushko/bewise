using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SovaTranslate_001.Models;
namespace SovaTranslate_001.Controllers
{
    [CustomAttribute.PageAuthorize(UserRoles="3")]
    public class AdminController : Controller
    {
        //
        // GET: /admin/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserList()
        {
            return View(DataBase.GetAllUsers());
        }
        public ActionResult ChangeRole(string roleid, string idUser){
        DataBase.ChangeRole(Convert.ToInt32(roleid), Convert.ToInt32(idUser));
        return RedirectToAction("Index");
        }
        
        public ActionResult AddTranslator(int id) {
            return View(DataBase.GetUser(id));
        }
        [HttpPost]
        public ActionResult AddTranslatorSave(AddTranslatorT t){
            int idSpec;
            if (t.specializationTrAdd != null)
            {
                 idSpec= DataBase.AddSpecialization(t.specializationTrAdd, t.isL,t.complexity);
               DataBase.AddPrice(idSpec, t.IdUser, t.pricespec);
               t.specializationTr.Add(idSpec);
            }
            
            for(int i=0;i<t.price.Count;i++){
                DataBase.AddPrice(t.specializationTr[i], t.IdUser, t.price[i]);
            }
            DataBase.AddTranslator(t.specializationTr.ToArray(), t.IdUser); 
            return View();
        }
        public ActionResult  GenereteReport()
        {
            sovadb001Entities0 db = new sovadb001Entities0();
            Report rep = new Report();
            rep.countadmin = db.users.Where(t => t.roleid == 3).ToArray().Length;

            rep.countoperator = db.users.Where(t => t.roleid == 2).ToArray().Length;

            rep.countmanager = db.users.Where(t => t.roleid == 1).ToArray().Length;

            rep.countuser = db.users.Where(t => t.roleid == 0).ToArray().Length;
            rep.ord = db.orders.Where(t => t.isDone == true && t.dateOfCompletion.Month > DateTime.Now.Month - 1).ToList();
            double r = 0;
            foreach (var i in rep.ord)
            {
                r += (double)i.totalCost;
            }
            return View(rep);
        }
        
    }
}
