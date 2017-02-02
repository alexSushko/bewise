using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SovaTranslate_001.Models;
namespace SovaTranslate_001
{
  
    public static class DataBase
    {
        public static List<user> GetAllUsers()
        {
            var entity = new sovadb001Entities0();
            return entity.users.ToList();
        }
        public static user GetUser(int id) {
            var entity = new sovadb001Entities0();
            user user = entity.users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.password = "";
                return user;
            }
            else return null;
        }

        public static bool UpdateUser(user userUpdate, HttpContextBase httpContext)
        {
            var authCookie = httpContext.Request.Cookies["__AUTH"];
            var entity = new sovadb001Entities0();

            if (authCookie != null)
            {
                user user = entity.users.FirstOrDefault(u => u.cookies == authCookie.Value);

                user.name = userUpdate.name;
                user.email = userUpdate.email;
                entity.SaveChanges();
                return true;
            }
            else return false;
        }
            public static bool UpdateUser(user userUpdate) {
            
            var entity = new sovadb001Entities0();
                user us = entity.users.First(t=>t.Id==userUpdate.Id);
            if (us != null)
            {
                
                us.name = userUpdate.name;
                us.email = userUpdate.email;
                entity.SaveChanges();
                return true;
            }

            return false;
            
        }
        public static List<order> GetUserOrders(user u) { 
            var entity = new sovadb001Entities0();
            return entity.orders.Where(f => f.idUser == u.Id).ToList();
            
        }
        public static bool isAppUser(int idApp, int idUser)
        {
            var entity = new sovadb001Entities0();
            var ord = entity.orders.First(t => t.IdOrder == idApp);

            if (ord != null)
            {
                if (entity.users.First(t => t.Id == ord.idUser)!=null) return true;
            }
            return false;
        }
        public static void DeleteApplication(int id) {
            var entity = new sovadb001Entities0();
            //auth.AuthHelper.GetUser(HttpContext);
            foreach (var t in entity.documentSpecializations.Where(r=>r.IdOrder==id)){
                entity.documentSpecializations.Remove(t);
            }
            foreach(var t in entity.documents.Where(r=>r.idOrder==id)){
                System.IO.File.Delete("C:\\Users\\Олександр\\Documents\\Visual Studio 2012\\Projects\\SovaTranslate_001\\SovaTranslate_001\\Content\\file\\" + t.pathToDoc);
                entity.documents.Remove(t);
            }
            entity.orders.Remove(entity.orders.First(r => r.IdOrder == id));
            entity.SaveChanges();

        }
        public static void AddApplication(order Order)
        {

            var entity = new sovadb001Entities0();
            entity.orders.Add(Order);
            entity.SaveChanges();
        }
        public static void AddDocSpec(documentSpecialization docSpec) {
            var entity = new sovadb001Entities0();
            entity.documentSpecializations.Add(docSpec);
            entity.SaveChanges();
        }
        public static void AddDoc(document doc){
          var entity = new sovadb001Entities0();
            entity.documents.Add(doc);
            entity.SaveChanges();
        }
        public static specialization GetSpecialization(int id) {

            var entity = new sovadb001Entities0();
            return entity.specializations.FirstOrDefault (t => t.IdSpecialization == id);
        }
        public static specialization GetSpecialization(int? id)
        {

            var entity = new sovadb001Entities0();
            return entity.specializations.FirstOrDefault(t => t.IdSpecialization == id);
        }
        public static List<document> GetAllDocumentsByOrder(int idOrder) {
            var entity = new sovadb001Entities0();

            return entity.documents.Where(u => u.idOrder == idOrder).ToList();
        }
        public static user GetUserByCookeis(string cookies)
        {
            var entity = new sovadb001Entities0();

            return entity.users.FirstOrDefault(u => u.cookies == cookies);
        }
        public static void AddUser(user us)
        {
            var entity = new sovadb001Entities0();

            entity.users.Add(us);
            entity.SaveChanges();
        }
        public static user GetUser(string email, string password)
        {
            var entity = new sovadb001Entities0();

            return entity.users.FirstOrDefault(u => u.email == email && u.password == password);
        }
        public static IEnumerable<specialization> GetSpecialization(bool isL) {
            var entity = new sovadb001Entities0();
            return entity.specializations.Where(t=>t.isLanguage==isL);
        }
        public static List<order> GetAllOrders()
        {
            var entity = new sovadb001Entities0();
            return entity.orders.ToList();
        }
        public static List<order> GetAllOrdersInProgress()
        {
            var entity = new sovadb001Entities0();
            return entity.orders.Where(t => t.isDone == false&&t.inProgress==false).ToList();

        }
        public static order GetOrder(int idOrder)
        {
            var entity = new sovadb001Entities0();
            return entity.orders.FirstOrDefault(t => t.IdOrder == idOrder);
        }
        public static List<specialization> GetSpecialization(List<price> prices) {
            var entity = new sovadb001Entities0();
            List<specialization> spec = new List<specialization>();
            foreach (var p in prices) {
                spec.Add(GetSpecialization(p.IdSpecialization));
            }
            return spec;
        }
        public static List<translator> GetTranslators(int idOrders) {
            var entity = new sovadb001Entities0();
            order ord = GetOrder(idOrders);
            List<translator> tr = new List<translator>();
            List<translator> translators = entity.translators.ToList();
            foreach (var t in translators) {
                bool flag=false;
                List<specialization> spec = GetSpecialization(t.prices.ToList());
                foreach (var o in ord.documentSpecializations) {
                     flag = false;
                    foreach(var x  in spec)
                    if (x.IdSpecialization==(o.IdSpecialization)) {
                        flag = true;
                        
                    } if (!flag) {break; } 
                }
                if (flag) tr.Add(t);
            }
            return tr;
        }
        public static float GetCost(int idOrder, translator translator) {
            var entity = new sovadb001Entities0();
            var order = GetOrder(idOrder);
            float cost=0;
            int i=0;float t=0;
            foreach (var ord in order.documentSpecializations) {
                t+=(float)translator.prices.FirstOrDefault(r => r.IdSpecialization == ord.IdSpecialization).price1;
                i++;
            }
            cost = t / i;
            return cost;
        }
        public static translator GetTranslator(int id) {
            var entity = new sovadb001Entities0();
            return entity.translators.First(t => t.IdTranslator == id);
        }
        public static void AddQueue(int idOrder, int idTranslator) {
            var entity = new sovadb001Entities0();
            queue nqueue = new queue();
            nqueue.IdTranslator = idTranslator;
            nqueue.IdOrder = idOrder;
            nqueue.cost = DataBase.GetCost(idOrder, GetTranslator(idTranslator));
            entity.queues.Add(nqueue);


            entity.orders.First(t => t.IdOrder == idOrder).inProgress = true;
            entity.orders.First(t => t.IdOrder == idOrder).totalCost = DataBase.GetCost(idOrder, GetTranslator(idTranslator));
                entity.SaveChanges();
            
        }
        public static void OrderIsDone(int idOrder) {
            var entity = new sovadb001Entities0();
            entity.orders.First(t => t.IdOrder == idOrder).isDone = true ;
            entity.SaveChanges();
        }
        public static void ChangeRole(int roleid, int idUser) {
            var entity = new sovadb001Entities0();
            entity.users.First(t => t.Id == idUser).roleid = roleid;
            entity.SaveChanges();
        }
        public static List<specialization> GetSpecializations()
        {
            var entity = new sovadb001Entities0();
            return entity.specializations.ToList();
        }
        public static bool orderIsUser(int idorder, int iduser)
        {
            var entity = new sovadb001Entities0();
            return entity.orders.First(t => t.IdOrder == idorder).idUser == iduser;
        }
        public static int AddSpecialization(string name, bool isL,int complexity) {
            var entity = new sovadb001Entities0();
            specialization spec = new specialization();
            spec.name=name;
            spec.isLanguage = isL;
            spec.complexity = complexity;
            entity.specializations.Add(spec);
            entity.SaveChanges();
            return entity.specializations.First(t => t.name == name).IdSpecialization;
        }
        public static void  AddPrice(int idSpec, int IdUser, double pricespec){
            var entity = new sovadb001Entities0();
            price np = new price();
            np.IdSpecialization = idSpec;
            np.IdTranslator = entity.translators.First(t => t.IdUser == IdUser).IdTranslator;
            np.price1 = pricespec;
            entity.prices.Add(np);
            entity.SaveChanges();
    }
        public static string GetLanguageName(int id) {
            var entity = new sovadb001Entities0();
            return entity.specializations.First(t => t.isLanguage == true && t.IdSpecialization == id).name;
        }
        public static void AddTranslator(int[] idSpec, int idUser)
        {
            var entity = new sovadb001Entities0();
            translator nt = new translator();
            nt.countOfComplitedOrders = 0;
            nt.IdUser = idUser;
            entity.translators.Add(nt);
            entity.SaveChanges();
            double[] p = new double[idSpec.Length];
            int x=0;
            foreach (int i in idSpec)
            {
                price pr = GetSpecialization(i).prices.First(t=>t.IdTranslator == entity.translators.First(q=>q.IdUser==idUser).IdTranslator);
                    specialization s = GetSpecialization(i);
                    if (pr != null)
                    {
                        p[x] = (double)(pr.price1 / s.complexity);
                    }
                    else p[x] = 0;
                    x++;


            }
            double sum=0;
            for (int i = 0; i < p.Length; i++)
            {
                sum += p[i];

            }
            sum /= p.Length;
            double sum1 = 0;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] != 0) {
                    p[i] -= sum;
                    p[i] = Math.Abs(p[i]);
                    sum1 += p[i];
                }
            }
            entity.translators.First(q => q.IdUser == idUser).reputation = (int)sum1;
            entity.SaveChanges();
        }
    }
}