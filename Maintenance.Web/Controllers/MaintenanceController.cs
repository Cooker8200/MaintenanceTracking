using Maintenance.Business;
using Maintenance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maintenance.Web.Controllers
{
    public class MaintenanceController : Controller
    {
        public MaintenanceController()
        {
            _maintenanceManager = new MaintenanceManager();
        }

        private MaintenanceManager _maintenanceManager;

        public ActionResult MaintenanceHome()
        {
            return View();
        }

        public ActionResult MaintenanceRecords()
        {
            var MaintenanceList = _maintenanceManager.List();
            return View(MaintenanceList);
        }

        public ActionResult TryAgain()
        {
            return View();
        }

        public ActionResult Create()
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
            Store.Add(new SelectListItem { Text = "Office", Value = "" });
            ViewBag.Store = Store;

            List<SelectListItem> RepairType = new List<SelectListItem>();
            RepairType.Add(new SelectListItem { Text = "Refridgeration", Value = "Refridgeration" });
            RepairType.Add(new SelectListItem { Text = "Technology", Value = "Technology" });
            RepairType.Add(new SelectListItem { Text = "HVAC", Value = "HVAC" });
            RepairType.Add(new SelectListItem { Text = "Physical", Value = "Physical" });
            ViewBag.RepairType = RepairType;

            List<SelectListItem> Vendor = new List<SelectListItem>();
            Vendor.Add(new SelectListItem { Text = "OTM", Value = "OTM" });
            Vendor.Add(new SelectListItem { Text = "Kitchen Solutions", Value = "Kitchen Solutions" });
            Vendor.Add(new SelectListItem { Text = "Comfort Experts", Value = "Comfort Experts" });
            Vendor.Add(new SelectListItem { Text = "Ostmann Construction", Value = "Ostmann Construction" });
            ViewBag.Vendor = Vendor;

            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        // !!! Old Method using model !!!
        //public ActionResult CreateRecord(MaintenanceLog MaintenanceLog)
        //{



        //    if (ModelState.IsValid)
        //    {
        //        _maintenanceManager.CreateRecord(MaintenanceLog);
        //        return View("RecordAdded");
        //    }
        //    else
        //    {
        //        return View("TryAgain");
        //    }

        //}

        public ActionResult CreateRecord(string Store, DateTime ServiceDate, string Vendor, int Invoice, string RepairType, string RepairDetail)
        { 
            
            if (ModelState.IsValid)
            {
                _maintenanceManager.CreateRecord(Store, ServiceDate, Vendor, Invoice, RepairType, RepairDetail);
                return View("RecordAdded");
            }
            else
            {
                return View("TryAgain");
            }

        }

        public ActionResult MaintenanceSearch()
        {
            return View();
        }

        public ActionResult SearchStore()
        {
            return PartialView("_SearchStore");
        }
        public ActionResult SearchDates()
        {
            return PartialView("_SearchDates");
        }
        public ActionResult SearchVendor()
        {
            return PartialView("_SearchVendor");
        }
        public ActionResult SearchRepairType()
        {
            return PartialView("_SearchRepairType");
        }

        public ActionResult StoreRecords(string storetext)  
        {
            var StoreSearchRecords = _maintenanceManager.StoreSearch(storetext);
            return View("StoreSearchResults", StoreSearchRecords);
        }

        public ActionResult DateRecords(string startdate, string enddate)
        {

            var DateSearchRecords = _maintenanceManager.DateSearch(startdate, enddate);
            return View("StoreSearchResults", DateSearchRecords);

        }
        public ActionResult VendorRecords(string vendortext)
        {
            var VendorSearchRecords = _maintenanceManager.VendorSearch(vendortext);
            return View("StoreSearchResults", VendorSearchRecords);
        }

        public ActionResult RepairTypeRecords(string repairtext)
        {
            var RepairTypeRecords = _maintenanceManager.VendorSearch(repairtext);
            return View("StoreSearchResults", RepairTypeRecords);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult EditStepTwo()
        {
            return PartialView("_EditStepTwo");
        }

        public ActionResult EditReturnRecords(string searchtext1, string searchtext2)
        {
            var EditResults = _maintenanceManager.EditSearch(searchtext1, searchtext2);
            return View("_EditResults", EditResults);

        }

        public ActionResult EditRecord (int? id)
        {
            var MaintRecord = _maintenanceManager.ManagerFindId(id);
            return View(MaintRecord);
        }

        public ActionResult SaveRecord (MaintenanceLog model)
        {
            if (ModelState.IsValid)
            {
                _maintenanceManager.ManagerSaveEdit(model);
                return View("Edit");
            }

            else
            {
                return View("TryAgain");
            }
        }

    }
}