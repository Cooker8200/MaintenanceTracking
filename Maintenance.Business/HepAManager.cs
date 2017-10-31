using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maintenance.Data.DataAccess;
using Maintenance.Models;

namespace Maintenance.Business
{
    public class HepAManager
    {
        public HepAManager()
        {
            _dataAccess = new Data.DataAccess.DataManager();
        }

        private Data.DataAccess.DataManager _dataAccess;

        public IEnumerable<HepA> HepASearch (string searchtext)
        {
            var ManagerHepA = _dataAccess.HepARecords(searchtext);
            return ManagerHepA;
        }

        public Array WeeklyReport()
        {
            var WeeklyReport = _dataAccess.WeeklyReport();
            return WeeklyReport;
        }
    }
}
