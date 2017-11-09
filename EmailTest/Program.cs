using Maintenance.Business;
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
            var test = new ContactManager();

            var SendTo = "Cooker8200@hotmail.com";
            var Name = "Matt";
            var Equipment = "POS";
            var Location = "Front Counter";
            var Problem = "Reg 3 not powering on";
            var StoreName = Console.ReadLine();

            test.SendOtp(SendTo, Name, Equipment, Location, Problem, StoreName);
        }
    }
}
