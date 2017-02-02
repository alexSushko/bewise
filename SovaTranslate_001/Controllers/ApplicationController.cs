using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SovaTranslate_001.Models;
using System.IO;
using Puma.Net;
using System.Drawing;
using Spire.Doc;
using Spire.Doc.Documents;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Drive.v3;
//using Google.Apis.Drive.v3.Data;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
//using Word = Microsoft.Office.Interop.Word;
//using Office = Microsoft.Office.Core;
//using Novacode;
namespace SovaTranslate_001.Controllers
{

    public class ApplicationController : Controller
    {
        //
        // GET: /Application/

        //static string[] Scopes = { DriveService.Scope.DriveFile };
        //static string ApplicationName = "Drive API .NET Quickstart";
        [CustomAttribute.PageAuthorize(UserRoles = "0,1")]
        [HttpGet]
        public ActionResult Register()
        {
            user userOrder = auth.AuthHelper.GetUser(HttpContext);
            if (userOrder.roleid == 1 )
            {
                return View(new RegisterApplicationForm() { userId = Convert.ToInt32(TempData["userId"]) });
            }
            else
            {

                return View(new RegisterApplicationForm());

            }
            //return View(new RegisterApplicationForm());
        }
    //[CustomAttribute.PageAuthorize(UserRoles = "0")]
    //[HttpGet]
    //public ActionResult Register(RegisterApplicationForm errReg)
    //{
    //    if (errReg == null) return View(new RegisterApplicationForm());
    //    return View(errReg);
    //}
        
        //private float textPrice(int[] spec, int symbols) {
        //    float price = 0;
        //    int avarageSpec = 0;
        //    foreach (int s in spec) {
        //        avarageSpec += s;
        //    }
        //    avarageSpec /= spec.Length;
        //    price = ((float)(avarageSpec * symbols)) / 10000;

        //    return price;
        //}
    [CustomAttribute.PageAuthorize(UserRoles = "0,1")]
        [HttpPost]
    public ActionResult Apply(RegisterApplicationForm doc)
    {
        if (ModelState.IsValid)
        {
            if (doc.UploadedFiles != null && doc.UploadedFiles[0] != null)
            {
                if(!Directory.Exists(Server.MapPath("~/Content/Temporary/" + auth.AuthHelper.GetUser(HttpContext).name))){
                    Directory.CreateDirectory(Server.MapPath("~/Content/Temporary/" + auth.AuthHelper.GetUser(HttpContext).name));
                }
                int i = 0;
                
                float priceOrder = 0;
                int[] specComplexity = new int[doc.spec.Length];
                foreach (int spec in doc.spec) {
                    specComplexity[i] = (int)DataBase.GetSpecialization(spec).complexity;
                }
                i = 0;
                List<double [,]> nspecdocs= new List<double [,]>();
                foreach (var UploadedFile in doc.UploadedFiles)
                {
                    bool img = false;
                    string fileName = System.IO.Path.GetFileName(UploadedFile.FileName);
                    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    var random = new Random();
                    string nfilename = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
                    nfilename += "." + fileName.Split('.')[1];
                   

                    UploadedFile.SaveAs(Server.MapPath("~/Content/Temporary/" + auth.AuthHelper.GetUser(HttpContext).name) + "\\" + nfilename);

                    //string result = TextParsing.ImgToFile(Server.MapPath("~/Content/Temporary/" + auth.AuthHelper.GetUser(HttpContext).name) + "\\" + nfilename, doc.Language);
                    
                    //if (result != null)
                    //{
                    //    img = true;
                    //    string nfilenameTranslate = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray())+".txt";
                    //    System.IO.File.WriteAllText(Server.MapPath("~/Content/Temporary/" + auth.AuthHelper.GetUser(HttpContext).name) + "\\" + nfilenameTranslate, result);
                    //    doc.translatefileNames[i] = nfilenameTranslate;
                    //} 

                    //string filenameToCountSymbols;
                    //if (doc.translatefileNames != null && doc.translatefileNames[i] != null) {  filenameToCountSymbols = doc.translatefileNames[i]; }
                    //else filenameToCountSymbols = nfilename;
                    //int count = countSymbolsIndoc(Server.MapPath("~/Content/Temporary/" + auth.AuthHelper.GetUser(HttpContext).name) + "\\" + filenameToCountSymbols, filenameToCountSymbols.Split('.')[1]);
                    //priceOrder += textPrice(specComplexity, count);
                    //nspecdocs.Add( TextParsing.TextSpecialization(Server.MapPath("~/Content/Temporary/" + auth.AuthHelper.GetUser(HttpContext).name) + "\\" + filenameToCountSymbols,doc.Language));
                    //i++;
                }
                
            }
        
            return View(doc);
        }
        else
        {
            
            if (doc.UploadedFiles != null && doc.UploadedFiles[0] != null)
            foreach (var UploadedFile in doc.UploadedFiles)
            {
               // string fileName = System.IO.Path.GetFileName(UploadedFile.FileName);
                //if(Directory.Exists(Server.MapPath("~/Content/Temporary/" + auth.AuthHelper.GetUser(HttpContext).name))&&System.IO.File.Exists(Server.MapPath("~/Content/Temporary/" + auth.AuthHelper.GetUser(HttpContext).name +"\\" +fileName)))
               // System.IO.File.Delete(Server.MapPath("~/Content/Temporary/" + auth.AuthHelper.GetUser(HttpContext).name +"\\" +fileName));
            }
            return View("~/Views/Application/Register.cshtml", doc);
            
        }
        //else return RedirectToAction("Register", "Application",doc);
    }
    [CustomAttribute.PageAuthorize(UserRoles = "0,1")]
    [HttpPost]
    public ActionResult Save(RegisterApplicationForm doc)
    {
        var entity = new sovadb001Entities0();
        
        order norder = new order();
        //entity.orders.Add(norder);
        
        
        int[] specComplexity = new int[doc.spec.Length+1];
        int i =1;
        specComplexity[0] = (int)DataBase.GetSpecialization(doc.Language).complexity;
        documentSpecialization dc = new documentSpecialization();
        dc.IdSpecialization = DataBase.GetSpecialization(doc.Language).IdSpecialization;
        entity.documentSpecializations.Add(dc);
        foreach (var spec in doc.spec)
        {
            specComplexity[i] = (int)DataBase.GetSpecialization(spec).complexity;
            i++;
            documentSpecialization ndocSpec = new documentSpecialization();
            //ndocSpec.order = norder;
            ndocSpec.IdOrder = norder.IdOrder;
           // ndocSpec.specialization = DataBase.GetSpecialization(spec);
            ndocSpec.IdSpecialization = DataBase.GetSpecialization(spec).IdSpecialization;
            
            //DataBase.AddDocSpec(ndocSpec);
           
            entity.documentSpecializations.Add(ndocSpec);
           // norder.documentSpecializations.Add(ndocSpec);
        }
        
       
        norder.dateOfCompletion = DateTime.Now;
        norder.name = doc.name;
        norder.description = doc.description;
        norder.deadline = doc.deadline;
        user iduser = auth.AuthHelper.GetUser(HttpContext);
        if(iduser.roleid == 1&&doc.userId!=0){
            norder.idUser = doc.userId;
        }
        else {
            
        norder.idUser = auth.AuthHelper.GetUser(HttpContext).Id;
            
        }
        norder.isDone = false;
        norder.inProgress = false;
        //DataBase.AddApplication(norder);
        entity.orders.Add(norder);
        entity.SaveChanges();
       
        return RedirectToAction("Index","Home");
        // }
    }
    //public ActionResult Submit() { 
        
    //}
    private int countSymbolsIndoc(string filename, string format) {

        Document doc = new Document();
        try
        {
            switch (format)
            {

                case "doc": { doc.LoadFromFile(@filename, FileFormat.Doc); break; }
                case "docx": { doc.LoadFromFile(@filename, FileFormat.Auto); break; }
                case "txt": { doc.LoadFromFile(@filename, FileFormat.Txt); break; }
            }
        }
        catch (Exception e) { }
        return doc.BuiltinDocumentProperties.CharCount;
        //DocX docum = DocX.Load(filename);
        //Office.
        
    }
    public ActionResult DeleteApp(int idApp) {
        if(DataBase.isAppUser(idApp, auth.AuthHelper.GetUser(HttpContext).Id))
        DataBase.DeleteApplication(idApp);
        return RedirectToAction("Orders","User");
    }
    public ActionResult View(int idOrder)
    {
        if (DataBase.orderIsUser(idOrder, auth.AuthHelper.GetUser(HttpContext).Id) || auth.AuthHelper.GetUser(HttpContext).roleid == 1 || auth.AuthHelper.GetUser(HttpContext).roleid == 2 || auth.AuthHelper.GetUser(HttpContext).roleid == 3)
            return View(DataBase.GetOrder(idOrder));
        else return RedirectToAction("Index");

    }
        public ActionResult Index()
        {
             //savaFile();
            return View();
        }
        [CustomAttribute.PageAuthorize(UserRoles = "1,2,3")]
        [HttpPost]
        public ActionResult AddTranslation(int idOrder, HttpPostedFileBase[] UploadedFiles)
        {
            sovadb001Entities0 db = new sovadb001Entities0();
           // order o = db.orders.First(t => t.IdOrder == idOrder);
            foreach (var UpF in UploadedFiles)
            {
                string fileName = System.IO.Path.GetFileName(UpF.FileName);
                UpF.SaveAs(Server.MapPath("~/Content/translate/") + fileName);
                document ndoc = new document();
                ndoc.pathToDoc = fileName;
                ndoc.isTranslate = true;
                ndoc.idOrder = idOrder;
                db.documents.Add(ndoc);
            }
            db.orders.First(t => t.IdOrder == idOrder).isDone = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

        //static string[] Scopes = { DriveService.Scope.DriveReadonly };
        //static string ApplicationName = "My Project";

        //static void savaFile()
        //{
        //    UserCredential credential;

        //    using (var stream =
        //        new FileStream("C:\\Users\\Олександр\\Documents\\Visual Studio 2012\\Projects\\SovaTranslate_001\\SovaTranslate_001\\Content\\client_secret_333069443770-recd4odtui8hc3m0an4hhag12jadg3tt.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
        //    {
        //        string credPath = System.Environment.GetFolderPath(
        //            System.Environment.SpecialFolder.Personal);
        //        credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");

        //        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
        //            GoogleClientSecrets.Load(stream).Secrets,
        //            Scopes,
        //            "user",
        //           System.Threading.CancellationToken.None,
        //            new FileDataStore(credPath, true)).Result;
        //        Console.WriteLine("Credential file saved to: " + credPath);
        //    }

        //    // Create Drive API service.
        //    var service = new DriveService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = credential,
        //        ApplicationName = ApplicationName,
        //    });

        //    // Define parameters of request.
        //    FilesResource.ListRequest listRequest = service.Files.List();
        //    listRequest.PageSize = 10;
        //    listRequest.Fields = "nextPageToken, files(id, name)";

        //    // List files.
        //    IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
        //        .Files;
        //    Console.WriteLine("Files:");
        //    if (files != null && files.Count > 0)
        //    {
        //        foreach (var file in files)
        //        {
        //            System.Diagnostics.Debug.WriteLine("{0} ({1})", file.Name, file.Id);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No files found.");
        //    }
            

        //}
    }
}
