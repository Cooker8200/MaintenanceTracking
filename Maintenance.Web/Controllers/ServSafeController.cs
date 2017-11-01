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
            //todo change results view if no data displayed from database
            var results = _ServSafeManager.ServSafeManagerSearch(searchtext);
            return PartialView ("_ServSafeResults", results);
        }
    }
}