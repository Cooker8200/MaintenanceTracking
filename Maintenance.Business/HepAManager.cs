using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maintenance.Data.DataAccess;
using Maintenance.Models;
using Maintenance.Models.ViewModels;

namespace Maintenance.Business
{
    public class HepAManager
    {
        public HepAManager()
        {
            _dataAccess = new Data.DataAccess.DataManager();
        }

        private Data.DataAccess.DataManager _dataAccess;

        //Hep A search function
        public IEnumerable<HepA_ViewModels> HepASearch (int searchval)
        {
            var ManagerHepA = _dataAccess.HepARecords(searchval);
            return ManagerHepA;
        }

        
        public IEnumerable<HepA_ViewModels> WeeklyReport()
        {
            var WeeklyReport = _dataAccess.WeeklyReport();
            return WeeklyReport;
        }

        public List<Stores> StoreList()
        {
            var Stores = _dataAccess.StoreList();
            return Stores;
        }

        public List<HepA_ViewModels> StoreHepAReport(int input)
        {
            var HepA_Store = _dataAccess.StoreHepAReport(input);
            return HepA_Store;
        }

        public List<HepA_ViewModels> SupervisorReport(int supid)
        {
            var SupReport = _dataAccess.SupervisorWeeklyReport(supid);
            return SupReport;
        }

        public List<SupervisorList_ViewModel> SupervisorList()
        {
            var SupList = _dataAccess.SupervisorList();
            return SupList;
        }
    }
}
