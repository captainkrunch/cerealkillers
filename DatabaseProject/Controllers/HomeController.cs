using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseProject.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("Visitor", "Home");
            }

            return View();
        }

        public ActionResult Visitor()
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

        public ActionResult Photos()
        {
            return View();
        }

        public ActionResult UpcomingEvents()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        }
    }
}