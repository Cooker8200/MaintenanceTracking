using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maintenance.Models;
using System.Data.Entity;

namespace Maintenance.Data.DataAccess
{
    public class DataManager
    {
        private DataContext db = new DataContext();

        public Data.Entities dbtwo = new Data.Entities();

        public IEnumerable<MaintenanceLog> List()
        {
            var MaintenanceList = db.MaintenanceLog.ToList();
            return MaintenanceList;
        }

        public void Create(MaintenanceLog MaintenanceLog)
        {
            //var dbitem = db.MaintenanceLog.FirstOrDefault(x => x.Id == MaintenanceLog.Id);
            //if (dbitem == null)
            //{
            //    var error = "It's broken!";
            //    Console.WriteLine(error);
            //}
            //else if (dbitem != null)
            //{
            //    dbitem.Id = MaintenanceLog.Id;
            //    dbitem.StoreId = MaintenanceLog.StoreId;
            //    dbitem.ServiceDate = MaintenanceLog.ServiceDate;
            //    dbitem.VendorName = MaintenanceLog.VendorName;
            //    dbitem.Invoice = MaintenanceLog.Invoice;
            //    dbitem.RepairDetail = MaintenanceLog.RepairDetail;
            //    dbitem.RepairType = MaintenanceLog.RepairType;
            //    db.SaveChanges();
            //}
            //else 
            //{

            //}
            db.MaintenanceLog.Add(MaintenanceLog);
            db.SaveChanges();
        }

        public MaintenanceLog FindId(int? id)
        {
            var dbitem = db.MaintenanceLog.Find(id);
            return dbitem;
        }

        public void Delete(int? id)
        {
            var dbitem = db.MaintenanceLog.Find(id);
            db.MaintenanceLog.Remove(dbitem);
            db.SaveChanges();
        }

        public IEnumerable<MaintenanceLog> StoreSearch(string storetext)   
        {
            var DataStoreSearch = db.MaintenanceLog.Where(x => x.StoreName.Contains(storetext));
            return DataStoreSearch;
        }

        public IEnumerable<MaintenanceLog> DateSearch(string startdate, string enddate)
        {
            var DataDateSearch = db.MaintenanceLog.SqlQuery("sp_SearchDates " + startdate + " , " + enddate);
            //var DataDateSearch = db.MaintenanceLog.Where(startdate <= x => enddate);
            //var DataDateSearch = from d in 
            return DataDateSearch;
        }

        //public IEnumerable<sp_SearchDates_Result> DateSearch(DateTime startdate, DateTime enddate)
        //{
        //    var stored = dbtwo.sp_SearchDates(startdate, enddate);
        //    return stored;
        //}

        public IEnumerable<MaintenanceLog> VendorSearch(string vendortext)
        {
            var DataVendorSearch = db.MaintenanceLog.Where(x => x.VendorName.Contains(vendortext));
            return DataVendorSearch;
            
        }

        public IEnumerable<MaintenanceLog> RepairTypeSearch(string repairtext)
        {
            var DataRepairType = db.MaintenanceLog.Where(x => x.RepairType.Contains(repairtext));
            return DataRepairType;

        }


    }
}
