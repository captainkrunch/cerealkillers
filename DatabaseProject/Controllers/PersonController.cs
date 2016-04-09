using DatabaseProject.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseProject.Controllers
{
    public class PersonController : Controller
    {
        private DataDb dataDb = new DataDb();
        // GET: Person
        public ActionResult Index()
        {
            //var p = dataDb.Persons.Select(p=>)

            return View();
        }
    }
}