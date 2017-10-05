using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Maintenance.Web.Controllers
{
    public class HepAController : Controller
    {
        public ActionResult HepA()
        {
            return View();
        }

        public ActionResult StJohns()
        {
            return PartialView("_HepAResults");
        }
    }
}