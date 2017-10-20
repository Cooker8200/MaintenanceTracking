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

        //public Data.Entities dbtwo = new Data.Entities();

        public IEnumerable<MaintenanceLog> List()
        {
            var MaintenanceList = db.MaintenanceLog.ToList();
            return MaintenanceList;
        }

        public void Create(MaintenanceLog MaintenanceLog)
        {
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
            var DataDateSearch = db.MaintenanceLog.SqlQuery("mainsp_datesearch " + " ' " + startdate + " ' " + " , " + " ' " + enddate + " ' ");
            return DataDateSearch;
        }

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

        public IEnumerable<MaintenanceLog> StoreRecordsEdit (string edittext)
        {
            var DataEditRequest = db.MaintenanceLog.Where(x => x.StoreName.Contains(edittext));
            return DataEditRequest;
        }

        public IEnumerable<HepA> HepARecords (string searchtext)
        {
            var DataHepA = db.HepA.Where(x => x.Store.Contains(searchtext));
            return DataHepA;
        }

        public IEnumerable<ServSafe> ServSafeData(string searchtext)
        {
            var DataServSafe = db.ServSafe.Where(x => x.Store.Contains(searchtext));
            return DataServSafe;
        }

        public IEnumerable<MaintenanceLog> EditSearch (string searchtext1, string searchtext2)
        {
            var DataEditSearch = db.Database.SqlQuery<MaintenanceLog>("mainsp_editsearch " + " '" + searchtext1 + "' " + " , " + " '" + searchtext2 + "' ");
            //var DataEditSearch = db.MaintenanceLog.Where(x => x.StoreName.Contains(searchtext1) && x.StoreName);  //use and
            return DataEditSearch;
        }

        public MaintenanceLog FindRecord (int? id)
        {
            var DataRecord = db.MaintenanceLog.Find(id);
            return DataRecord;
        }

        public void SaveEdit (MaintenanceLog model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();

        }

        public HepA WeeklyReport()
        {
            //todo return null values
            //var HepA_Weekly = db.HepA.Where(x => x.SecondShot = );  
            //return HepA_Weekly;

            return null;
        }

    }
}
