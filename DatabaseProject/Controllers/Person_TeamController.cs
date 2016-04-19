using DatabaseProject.DataContexts;
using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseProject.Controllers
{
    public class Person_TeamController : Controller
    {
        private DataDb ddb = new DataDb();

        protected override void Dispose(bool disposing)
        {
            ddb.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View(ddb.P_Teams.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person_Team pTeam)
        {
            if (ModelState.IsValid)
            {
                ddb.P_Teams.Add(pTeam);
                ddb.SaveChanges();

                return RedirectToAction("Index", "Person_Team");
            }
            return View(pTeam);
        }

        public ActionResult Delete(int id = 0)
        {
            Person_Team pTeam = ddb.P_Teams.Find(id);
            if (pTeam == null)
            {
                return HttpNotFound();
            }
            return View(pTeam);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePTeam(int id = 0)
        {
            Person_Team pTeam = ddb.P_Teams.Find(id);

            if (pTeam != null)
            {
                ddb.P_Teams.Remove(pTeam);
                ddb.SaveChanges();
                return RedirectToAction("Index", "Person_team");
            }
            return View();
        }
    }
}