using Maintenance.Business;
using Maintenance.Data.DataAccess;
using Maintenance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //test method for contact manager
            var test = new ContactManager();
            var SendTo = "Cooker8200@hotmail.com";
            var Name = "Matt";
            var Equipment = "POS";
            var Location = "Front Counter";
            var Problem = "Reg 3 not powering on";
            var StoreName = "Ballwin";

            test.SendOtp(SendTo, Name, Equipment, Location, Problem, StoreName);

            //test method for maintenance manager
            //var dataTest = new MaintenanceManager();

            //test methods for scheduled task
            //var WeeklyTask = new DataManager();
            //var search = WeeklyTask.WeeklyReport();
        }
    }
}
