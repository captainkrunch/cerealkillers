using DatabaseProject.DataContexts;
using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseProject.Controllers
{
    public class PersonController : Controller
    {
        private DataDb ddb = new DataDb();

        protected override void Dispose(bool disposing)
        {
            ddb.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View(ddb.People.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                ddb.People.Add(person);
                ddb.SaveChanges();

                return RedirectToAction("Index","Person");
            }
            return View(person);
        }

        public ActionResult Details(int id = 0)
        {
            Person person = ddb.People.Find(id);

            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        public ActionResult Edit(int id = 0)
        {
            Person person = ddb.People.Find(id);

            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                ddb.Entry(person).State = System.Data.Entity.EntityState.Modified;
                ddb.SaveChanges();
                return RedirectToAction("Index", "Person");
            }
            return View();
        }

        public ActionResult Delete(int id = 0)
        {
            Person person = ddb.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePerson(int id = 0)
        {
            Person person = ddb.People.Find(id);

            if (person != null)
            {
                ddb.People.Remove(person);
                ddb.SaveChanges();
                return RedirectToAction("Index", "Person");
            }
            return View();
        }

    }
}