using Maintenance.Models;
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

        public IEnumerable<ServSafe> ServSafeManagerSearch(string searchtext)
        {
            var ManagerServSafe = _dataAccess.ServSafeData(searchtext);
            return ManagerServSafe;
        }
    }
}
