using System;
<<<<<<< HEAD
using System.IO;
using System.Web.Mvc;
using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
=======
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management_System.Models;
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4

namespace Hospital_Management_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

<<<<<<< HEAD
        public ActionResult ComplaintHelp()
        {
            return View();
        }

        public ActionResult ViewHelpDoc()
        {
            try
            {
                var path = Server.MapPath("~/Content/help/HELP_DOCUMENT.pdf");
                var AccesFilePath = Server.MapPath("~/Content/uploads/HELP_DOCUMENT.pdf");
                using (Viewer viewerObject = new Viewer(path))
                {
                    PdfViewOptions options = new PdfViewOptions(AccesFilePath);
                    viewerObject.View(options);
                }

                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                var fsResult = new FileStreamResult(fileStream, "application/pdf");
                return fsResult;
            }catch(Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //if we got here something went wrong
            return View();
        }

=======
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(Reviews model)
        //{

        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
>>>>>>> 3c552410d40ec94cbecda862c77b7e85a15807a4
    }
}