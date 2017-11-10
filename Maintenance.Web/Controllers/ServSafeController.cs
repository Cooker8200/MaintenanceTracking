using Maintenance.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maintenance.Web.Controllers
{
    public class ServSafeController : Controller
    {
        public ServSafeController()
        {
            _ServSafeManager = new ServSafeManager();
        }

        private Maintenance.Business.ServSafeManager _ServSafeManager;
        public ActionResult ServSafeHome()
        {
            return View();
        }

        public ActionResult Search (string searchtext)
        {
            var results = _ServSafeManager.ServSafeManagerSearch(searchtext);
            var recordCount = Convert.ToInt32(results.Count());
            if (recordCount == 0)
            {
                return PartialView("_NoRecordsFound");
            }
            else
            {
                return PartialView("_ServSafeResults", results);
            }

        }
    }
}