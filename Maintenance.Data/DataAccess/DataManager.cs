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

        // !!! Old model method !!!
        //public void Create(MaintenanceLog MaintenanceLog)
        //{
        //    db.MaintenanceLog.Add(MaintenanceLog);
        //    db.SaveChanges();
        //}

        public void Create(string Store, DateTime ServiceDate, string Vendor, int Invoice, string RepairType, string RepairDetail, string storeName)
        {
            var storeNumber = Convert.ToInt32(Store);  

            var createRecord = new MaintenanceLog();
            createRecord.Invoice = Invoice;
            createRecord.RepairDetail = RepairDetail;
            createRecord.RepairType = RepairType;
            createRecord.ServiceDate = ServiceDate;
            createRecord.StoreName = storeName;
            createRecord.VendorName = Vendor;
            createRecord.StoreId = storeNumber;        
            db.MaintenanceLog.Add(createRecord);
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

        public Array WeeklyReport()
        {
            //var HepA_Weekly = db.HepA.Where(x => x.SecondShot == null).ToList();
            var HepA_Weekly = db.Database.SqlQuery<HepA>("hepsp_weekly").ToArray();
            return HepA_Weekly;

        }

        public string ServiceAddHepA(string name, DateTime firstshot, DateTime? secondshot, string store)
        {

                var noSecondShot = new HepA();
                noSecondShot.EmpName = name;
                noSecondShot.FirstShot = firstshot;
                noSecondShot.SecondShot = secondshot;
                noSecondShot.Store = store;
                db.HepA.Add(noSecondShot);
                db.SaveChanges();

            return noSecondShot.EmpName;
                        
        }
    }
}
