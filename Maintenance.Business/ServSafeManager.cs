using Maintenance.Models;
using Maintenance.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Business
{
    public class ServSafeManager
    {
        public ServSafeManager()
        {
            _dataAccess = new Data.DataAccess.DataManager();
        }

        private Data.DataAccess.DataManager _dataAccess;

        public IEnumerable<ServSafe_ViewModels> ServSafeManagerSearch(int searchval)
        {
            var ManagerServSafe = _dataAccess.ServSafeData(searchval);
            return ManagerServSafe;
        }

        public List<Stores> StoresList()
        {
            var Stores = _dataAccess.StoreList();
            return Stores;
        }
        public List<ServSafe_ViewModels> ServSafeReport(int storeid)
        {
            var ServSafeData = _dataAccess.ServSafeReport(storeid);
            return ServSafeData;
        }
    }
}
