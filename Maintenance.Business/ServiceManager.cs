using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace Maintenance.Business
{
    public class ServiceManager
    {
        public ServiceManager()
        {
            _dataAccess = new Data.DataAccess.DataManager();
        }
        private Data.DataAccess.DataManager _dataAccess;
        public string ServiceAddRecord(string name, DateTime firstshot, DateTime? secondshot, string store)
        {
            var Service = _dataAccess.ServiceAddHepA(name, firstshot, secondshot, store);
            return Service;
        }
    }
}
