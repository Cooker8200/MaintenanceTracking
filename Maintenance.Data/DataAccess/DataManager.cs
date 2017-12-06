using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maintenance.Models;
using System.Data.Entity;
using Maintenance.Models.ViewModels;

namespace Maintenance.Data.DataAccess
{
    public class DataManager
    {
        private DataContext db = new DataContext();

        //public Data.Entities dbtwo = new Data.Entities();

        //get list of all maintenance records
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

        //create maintenance record
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

        //lookup maintenence record based on sql id
        public MaintenanceLog FindId(int? id)
        {
            var dbitem = db.MaintenanceLog.Find(id);
            return dbitem;
        }

        //delete maintenance record
        public void Delete(int? id)
        {
            var dbitem = db.MaintenanceLog.Find(id);
            db.MaintenanceLog.Remove(dbitem);
            db.SaveChanges();
        }

        //maintenance search functions
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

        //search records for specific store name
        public IEnumerable<MaintenanceLog> StoreRecordsEdit (string edittext)
        {
            var DataEditRequest = db.MaintenanceLog.Where(x => x.StoreName.Contains(edittext));
            return DataEditRequest;
        }

        //search Hep A records
        public IEnumerable<HepA_ViewModels> HepARecords (int searchval)
        {
            //todo update to take new parameters..change up through application
            var DataHepA = db.Database.SqlQuery<HepA_ViewModels>("hepsp_search" + " " + searchval).ToList();
            //var DataHepA = db.HepA.Where(x => x.Store.Contains(searchtext)); --- old method before relational database
            return DataHepA;
        }

        //search ServSafe records
        public IEnumerable<ServSafe_ViewModels> ServSafeData(int searchval)
        {
            var DataServSafe = db.Database.SqlQuery<ServSafe_ViewModels>("SSsp_search" + " " + searchval).ToList();
            //var DataServSafe = db.ServSafe.Where(x => x.Store.Contains(searchtext)); --- old method before relational database
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

        //weekly report function
        public IEnumerable<HepA_ViewModels> WeeklyReport()
        {
            var HepA_Weekly = db.Database.SqlQuery<HepA_ViewModels>("Weeklysp_HepASearch").ToList();
            return HepA_Weekly;
        }
    
        //weekly report function
        public List<HepA_ViewModels> StoreHepAReport(int input)
        {
            var HepA_Store = db.Database.SqlQuery<HepA_ViewModels>("Weeklysp_HepA_StoreRecords " + input).ToList();
            //var HepA_Store = db.HepA.Where(x => x.SecondShot == null && x.Store == input).ToList();
            return HepA_Store;
        }

        public List<Stores> StoreList()
        {
            var Stores = db.Stores.ToList();
            return Stores;
        }
        
        public List<ServSafe> ServSafeList()
        {
            var SS_Records = db.ServSafe.ToList();
            return SS_Records;
        }

        //todo rewrite service for update database
        //public string ServiceAddHepA(string name, DateTime? firstshot, DateTime? secondshot, string store)
        //{

        //        var noSecondShot = new HepA();
        //    noSecondShot.EmpName = name;
        //    noSecondShot.FirstShot = firstshot;
        //        noSecondShot.SecondShot = secondshot;
        //        noSecondShot.Store = store;
        //        db.HepA.Add(noSecondShot);
        //        db.SaveChanges();

        //    return noSecondShot.EmpName;

        //}
        
        
    }
}
