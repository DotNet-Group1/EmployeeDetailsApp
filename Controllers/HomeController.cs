using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDetailsApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult FileUpload()
        {
            //Add-Migration AddProfileImageAndCV
            //Update-Database
            
            //HttpPostedFileBase filename
            //if(filename != null)
            //{
            //    string profileImagePath = Path.Combine(Server.MapPath("~/Uploads/ProfileImage"), filename.FileName);
            //    filename.SaveAs(profileImagePath);
            //    teacher.propertyname = "~/Uploads/ProfileImage" + filename.FileName;
            //}
            return View();
        }
    }
}