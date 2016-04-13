using DatabaseProject.DataContexts;
using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseProject.Controllers
{
    public class ItemController : Controller
    {
        private DataDb ddb = new DataDb();

        protected override void Dispose(bool disposing)
        {
            ddb.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View(ddb.Items.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                ddb.Items.Add(item);
                ddb.SaveChanges();

                return RedirectToAction("Index", "Item");
            }
            return View(item);
        }

        public ActionResult Details(int id = 0)
        {
            Item item = ddb.Items.Find(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        public ActionResult Edit(int id = 0)
        {
            Item item = ddb.Items.Find(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                ddb.Entry(item).State = System.Data.Entity.EntityState.Modified;
                ddb.SaveChanges();
                return RedirectToAction("Index", "Item");
            }
            return View();
        }

        public ActionResult Delete(int id = 0)
        {
            Item item = ddb.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteItem(int id = 0)
        {
            Item item = ddb.Items.Find(id);

            if (item != null)
            {
                ddb.Items.Remove(item);
                ddb.SaveChanges();
                return RedirectToAction("Index", "Item");
            }
            return View();
        }
    }
}