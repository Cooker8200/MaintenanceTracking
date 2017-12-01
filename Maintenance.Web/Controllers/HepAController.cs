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

        public ActionResult Search(string searchtext, int searchval)
        {
            var HepAResults = _HepAmanager.HepASearch(searchval);
            var resultsCount = Convert.ToInt32(HepAResults.Count());
            if (resultsCount == 0)
            {
                ViewBag.Name = searchtext;
                return PartialView("_NoRecordsFound");
            }
            else
            {
                return PartialView("_HepAResults", HepAResults);
            }

        }

    }
}