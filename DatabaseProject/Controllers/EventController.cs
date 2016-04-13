using DatabaseProject.DataContexts;
using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseProject.Controllers
{
    public class EventController : Controller
    {
        private DataDb ddb = new DataDb();

        protected override void Dispose(bool disposing)
        {
            ddb.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View(ddb.Events.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event anEvent)
        {
            if (ModelState.IsValid)
            {
                ddb.Events.Add(anEvent);
                ddb.SaveChanges();

                return RedirectToAction("Index", "Event");
            }
            return View(anEvent);
        }

        public ActionResult Details(int id = 0)
        {
            Event anEvent = ddb.Events.Find(id);

            if (anEvent == null)
            {
                return HttpNotFound();
            }
            return View(anEvent);
        }

        public ActionResult Edit(int id = 0)
        {
            Event anEvent = ddb.Events.Find(id);

            if (anEvent == null)
            {
                return HttpNotFound();
            }
            return View(anEvent);
        }

        [HttpPost]
        public ActionResult Edit(Event anEvent)
        {
            if (ModelState.IsValid)
            {
                ddb.Entry(anEvent).State = System.Data.Entity.EntityState.Modified;
                ddb.SaveChanges();
                return RedirectToAction("Index", "Event");
            }
            return View();
        }

        public ActionResult Delete(int id = 0)
        {
            Event anEvent = ddb.Events.Find(id);
            if (anEvent == null)
            {
                return HttpNotFound();
            }
            return View(anEvent);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEvent(int id = 0)
        {
            Event anEvent = ddb.Events.Find(id);

            if (anEvent != null)
            {
                ddb.Events.Remove(anEvent);
                ddb.SaveChanges();
                return RedirectToAction("Index", "Event");
            }
            return View();
        }
    }
}