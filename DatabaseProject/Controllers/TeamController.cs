using DatabaseProject.DataContexts;
using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseProject.Controllers
{
    public class TeamController : Controller
    {
        private DataDb ddb = new DataDb();

        protected override void Dispose(bool disposing)
        {
            ddb.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View(ddb.Teams.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                ddb.Teams.Add(team);
                ddb.SaveChanges();

                return RedirectToAction("Index", "Team");
            }
            return View(team);
        }

        public ActionResult Details(int id = 0)
        {
            Team team = ddb.Teams.Find(id);

            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        public ActionResult Edit(int id = 0)
        {
            Team team = ddb.Teams.Find(id);

            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                ddb.Entry(team).State = System.Data.Entity.EntityState.Modified;
                ddb.SaveChanges();
                return RedirectToAction("Index", "Team");
            }
            return View();
        }

        public ActionResult Delete(int id = 0)
        {
            Team team = ddb.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteTeam(int id = 0)
        {
            Team team = ddb.Teams.Find(id);

            if (team != null)
            {
                ddb.Teams.Remove(team);
                ddb.SaveChanges();
                return RedirectToAction("Index", "Team");
            }
            return View();
        }
    }
}