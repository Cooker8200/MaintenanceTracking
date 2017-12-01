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

        public IEnumerable<HepA_ViewModels> HepASearch (int searchval)
        {
            var ManagerHepA = _dataAccess.HepARecords(searchval);
            return ManagerHepA;
        }

        public List<HepA> WeeklyReport()
        {
            var WeeklyReport = _dataAccess.WeeklyReport();
            return WeeklyReport;
        }

        public List<Stores> StoreList()
        {
            var Stores = _dataAccess.StoreList();
            return Stores;
        }

        public List<HepA> StoreHepAReport(string input)
        {
            var HepA_Store = _dataAccess.StoreHepAReport(input);
            return HepA_Store;
        }
    }
}
