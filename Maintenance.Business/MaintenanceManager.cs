using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maintenance.Data;
using Maintenance.Models;

namespace Maintenance.Business
{
    public class MaintenanceManager
    {
        public MaintenanceManager()
        {
            _dataAccess = new Data.DataAccess.DataManager();
        }

        private Data.DataAccess.DataManager _dataAccess;

        public IEnumerable<MaintenanceLog> List()
        {
            var MaintenanceList = _dataAccess.List();
            return MaintenanceList;
        }

        public void CreateRecord(MaintenanceLog MaintenanceLog)
        {
            _dataAccess.Create(MaintenanceLog);
        }

        public IEnumerable<MaintenanceLog> StoreSearch(string storetext) 
        {
            var ManagerStoreSearch = _dataAccess.StoreSearch(storetext);
            return ManagerStoreSearch;
        }

        public IEnumerable<MaintenanceLog> DateSearch(string startdate, string enddate)
        {
            var ManagerDateSearch = _dataAccess.DateSearch(startdate, enddate);
            return ManagerDateSearch;
        }

        public IEnumerable<MaintenanceLog> VendorSearch(string vendortext)
        {
            var ManagerVendorSearch = _dataAccess.VendorSearch(vendortext);
            return ManagerVendorSearch;
        }

        public IEnumerable<MaintenanceLog> RepairTypeSearch(string repairtext)
        {
            var ManagerRepairRecords = _dataAccess.RepairTypeSearch(repairtext);
            return ManagerRepairRecords;
        }

        public IEnumerable<MaintenanceLog> EditSearch (string searchtext1, string searchtext2)
        {
            var ManagerEditSearch = _dataAccess.EditSearch(searchtext1, searchtext2);
            return ManagerEditSearch;
        }

        public MaintenanceLog ManagerFindId (int? id)
        {
            var ManagerRecord = _dataAccess.FindId(id);
            return ManagerRecord;
        }

        public void ManagerSaveEdit(MaintenanceLog model)
        {
            _dataAccess.SaveEdit(model);
        }
    }
}
