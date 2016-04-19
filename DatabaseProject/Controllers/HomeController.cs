using DatabaseProject.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseProject.Controllers
{
    public class HomeController : Controller
    {
        private DataDb ddb = new DataDb();

        protected override void Dispose(bool disposing)
        {
            ddb.Dispose();
            base.Dispose(disposing);
        }

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
            var model = ddb.Events.ToList()
                .Where(e => ((e.Date - DateTime.Today).TotalDays >= 0 && (e.Date - DateTime.Today).TotalDays <= 7) && e.EndTime > DateTime.Now);

            return View(model);
        }

        public ActionResult FAQ()
        {
            return View();
        }
    }
}