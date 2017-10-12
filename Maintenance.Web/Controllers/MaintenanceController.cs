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
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult CreateRecord(MaintenanceLog MaintenanceLog)
        {
            if (ModelState.IsValid)
            {
                _maintenanceManager.CreateRecord(MaintenanceLog);
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
                return null;  //todo redirect somewhere
            }
        }

    }
}