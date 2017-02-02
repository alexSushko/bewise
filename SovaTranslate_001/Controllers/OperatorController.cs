using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SovaTranslate_001.Models;
namespace SovaTranslate_001.Controllers
{

    [CustomAttribute.PageAuthorize(UserRoles = "2")]
    public class OperatorController : Controller
    {
        //
        // GET: /operator/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Orders()
        {
            return View(DataBase.GetAllOrders());
        }
        [HttpGet]
        public ActionResult OrdersTranslations(int idOrder)
        {

            return View(idOrder);
        }
        
        public ActionResult ProcessingOfApplication() {
            return View(DataBase.GetAllOrdersInProgress());
        }
        [HttpGet]
        public ActionResult ViewOrder(int idOrder)
        {
            
            return View(new orderTranslators(idOrder,DataBase.GetTranslators(idOrder)));
        }

        [HttpPost]
        public ActionResult ViewOrder(int idOrder,int idTranslator) {
            sovadb001Entities0 db = new sovadb001Entities0();
            DataBase.AddQueue(idOrder,idTranslator);
            db.orders.First(t => t.IdOrder == idOrder).totalCost = DataBase.GetCost(idOrder, DataBase.GetTranslator(idTranslator));
            db.orders.First(t => t.IdOrder == idOrder).inProgress = true;
            return RedirectToAction("ProcessingOfApplication");
        }
       
       
        public ActionResult OrderIsDone(string idOrder)
        {
            DataBase.OrderIsDone(Convert.ToInt32(idOrder));

            return View();
        }

    }
}
