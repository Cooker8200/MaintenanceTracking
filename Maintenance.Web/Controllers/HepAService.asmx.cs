using Maintenance.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace Maintenance.Web.Controllers
{
    /// <summary>
    /// Summary description for HepAService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/", Description = "Hep A Service", Name = "HepASerivce")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HepAService : System.Web.Services.WebService
    {

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}

        //    public HepAService()
        //    {
        //        _ServiceManager = new Maintenance.Business.ServiceManager();
        //    }

        //    private ServiceManager _ServiceManager;

        //    [WebMethod]
        //    //todo rewrite for new database
        //    public ActionResult HepAServiceAdd(string name, DateTime firstshot, DateTime? secondshot, string store)
        //    {

        //        _ServiceManager.ServiceAddRecord(name, firstshot, secondshot, store);
        //        return null;
        //    }
    }
}
