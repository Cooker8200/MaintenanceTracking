using Maintenance.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Maintenance.Web.Controllers
{
    public class HepAController : Controller
    {
        public HepAController()
        {
            _HepAmanager = new HepAManager();
        }

        private HepAManager _HepAmanager;

        public ActionResult HepAHome()
        {
            return View("HepA");
        }

        public ActionResult Search(string searchtext)
        {
            var HepAResults = _HepAmanager.HepASearch(searchtext);
            return PartialView("_HepAResults", HepAResults);
        }

    }
}