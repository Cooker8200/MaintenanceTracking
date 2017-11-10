using Maintenance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maintenance.Web.Controllers
{
    public class ToolsController : Controller
    {
        public static void Lists()
        {
            List<SelectListItem> Store = new List<SelectListItem>();
            Store.Add(new SelectListItem { Text = "University City", Value = "" });
            Store.Add(new SelectListItem { Text = "Ballwin", Value = "2147" });
            Store.Add(new SelectListItem { Text = "Dorsett", Value = "" });
            Store.Add(new SelectListItem { Text = "Ashby", Value = "2750" });
            Store.Add(new SelectListItem { Text = "Lindell", Value = "" });
            Store.Add(new SelectListItem { Text = "Olivette", Value = "" });
            Store.Add(new SelectListItem { Text = "Clarkson", Value = "" });
            Store.Add(new SelectListItem { Text = "141", Value = "" });
            Store.Add(new SelectListItem { Text = "Overland Plaza", Value = "11003" });
            Store.Add(new SelectListItem { Text = "Howdershell", Value = "" });
            Store.Add(new SelectListItem { Text = "Earth City", Value = "" });
            Store.Add(new SelectListItem { Text = "Creve Coeur", Value = " " });
            Store.Add(new SelectListItem { Text = "St John's", Value = "32869" });
            Store.Add(new SelectListItem { Text = "Ellisville", Value = "" });
            Store.Add(new SelectListItem { Text = "Office", Value = "9999" });
            ViewBag.Store = Store;
            Session["StoreNames"] = Store;

            List<SelectListItem> RepairType = new List<SelectListItem>();
            RepairType.Add(new SelectListItem { Text = "Refridgeration", Value = "Refridgeration" });
            RepairType.Add(new SelectListItem { Text = "Technology", Value = "Technology" });
            RepairType.Add(new SelectListItem { Text = "HVAC", Value = "HVAC" });
            RepairType.Add(new SelectListItem { Text = "Physical", Value = "Physical" });
            RepairType.Add(new SelectListItem { Text = "Grills", Value = "Grills" });
            RepairType.Add(new SelectListItem { Text = "Fryers", Value = "Fryers" });
            ViewBag.RepairType = RepairType;

            List<SelectListItem> Vendor = new List<SelectListItem>();
            Vendor.Add(new SelectListItem { Text = "OTM", Value = "OTM" });
            Vendor.Add(new SelectListItem { Text = "Kitchen Solutions", Value = "Kitchen Solutions" });
            Vendor.Add(new SelectListItem { Text = "Comfort Experts", Value = "Comfort Experts" });
            Vendor.Add(new SelectListItem { Text = "Ostmann Construction", Value = "Ostmann Construction" });
            ViewBag.Vendor = Vendor;

        }

    }
}