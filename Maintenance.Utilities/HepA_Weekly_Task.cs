using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Maintenance.Business;
using Maintenance.Models;
using System.IO;
using System.Configuration;
using System.Web.Mvc;
using Maintenance.Models.ViewModels;

namespace Maintenance.Utilities
{
    public class HepA_Weekly_Task
    {
        public static void Main(string[] args)
        {
            //initialize managers
            var Contact = new ContactManager();
            var HepATask = new HepAManager();
            var ServSafeManager = new ServSafeManager();
            var message = "";
            var dayOfWeek = DateTime.Now.DayOfWeek;
            var dayOfMonth = DateTime.Now.Day;
            //Weekly Hep A Reporting
            if (dayOfWeek == DayOfWeek.Saturday || ConfigurationManager.AppSettings["Mode"] == "Test")
            {
                var records = HepATask.WeeklyReport();
                var stores = HepATask.StoreList();
                //create file and write records results to file
                var date = DateTime.Now.ToString("dd-MMM-yyyy");
                var fileName = date + " Weekly HepA.txt";
                //create report with all records
                var path = Path.Combine("C:\\Users\\Jennifer\\Desktop\\MaintenanceTracking\\Maintenance.Utilities\\WeeklyHepA_Report", fileName);//todo
                FileStream file = File.Create(path);

                using (StreamWriter write = new StreamWriter(file))
                {
                    write.WriteLine(DateTime.Now.ToString("dd-MMM-yyyy"));
                    foreach (var item in records)
                    {
                        //check for value of firstShot, if null possible database error and need to dig deeper
                        if(item.FirstShot == null)
                        {
                            write.WriteLine(item.Name + " has no shot information.  Please verfiy before scheduling.");
                        }
                        //check for value of firstShot is not in the future of current day
                        if (item.FirstShot > DateTime.Now && item.FirstShot.HasValue)
                        {
                            write.WriteLine(item.Name + " has invalid shot information.  Please check and update as necessary.");
                        }
                        //if firstShot passes the first two tests, then log appropriate information about time left before secondShot
                        if (item.FirstShot < DateTime.Now && item.FirstShot.HasValue)
                        {
                            var currentMonth = DateTime.Now.ToString("MM");
                            var currentMonthInt = Convert.ToInt32(currentMonth);
                            var firstDate = item.FirstShot.ToString();
                            var firstShotMonth = DateTime.Parse(firstDate).ToString("MM");
                            var writeFirstShot = DateTime.Parse(firstDate).ToString("dd-MMM-yyyy");
                            int month = Convert.ToInt32(firstShotMonth);
                            if (month <= 6)
                            {
                                var timeLeft = month + 6;
                                var time = timeLeft - currentMonthInt;
                                if (time > 6)
                                {

                                }
                                if (time >= 2 && time <= 6)
                                {
                                    var empGood = item.Name + " has " + time + " months left to get second HepA shot.";
                                    write.WriteLine(empGood + " -- First Shot: " + writeFirstShot);
                                }
                                if (time <= 1 && time > 0)
                                {
                                    var empBad = item.Name + " has less than 30 days to get second HepA shot.";
                                    write.WriteLine(empBad + " -- First Shot: " + writeFirstShot);
                                }
                                if (time <= 0)
                                {
                                    var offSch = item.Name + " MUST NOT WORK UNTIL SECOND HEP A SHOT!!";
                                    write.WriteLine(offSch + " -- First Shot: " + writeFirstShot);
                                }

                            }
                            if (month >= 7)
                            {
                                // conversions:
                                // 1-July, 2-August, 3-September, 4-October, 5-November, 6-December...7-January, 8-February, 9-March, 10-April, 11-May, 12-June
                                var lateDateExp = currentMonthInt - 6;      //current month rolled back by 6 for math
                                var lateFirstShot = month - 6;              //first shot month rolled back by 6 for math
                                var lateTimeLeft = lateFirstShot + 6;       //time when shot expires
                                var lateTime = lateTimeLeft - lateDateExp;   //amount of time left until shot expiration
                                if (lateTime > 6)
                                {

                                }
                                if (lateTime > 2 && lateTime <= 6)
                                {
                                    var empGood = item.Name + " has " + lateTime + " months left to get second HepA shot";
                                    write.WriteLine(empGood + " -- First Shot: " + writeFirstShot);
                                }
                                if (lateTime <= 1 && lateTime > 0)
                                {
                                    var empBad = item.Name + " has less than 30 days to get second HepA shot";
                                    write.WriteLine(empBad + " -- First Shot: " + writeFirstShot);
                                }
                                if (lateTime <= 0)
                                {
                                    var offSch = item.Name + " MUST NOT WORK UNTIL SECOND HEP A SHOT!!";
                                    write.WriteLine(offSch + " -- First Shot: " + writeFirstShot);
                                }
                            }
                        }
                    }
                }

                //search records by store and send individual email for issues
                var emailTemplate = "C:\\Users\\Jennifer\\Desktop\\MaintenanceTracking\\Maintenance.Utilities\\Email_Template\\HepA_Store_Template.html";//todo
                for (var s = 0; s < stores.Count(); s++)
                {
                    //get specific store information
                    var storeResults = HepATask.StoreHepAReport(stores[s].id);
                    //if zero records, send alert email
                    if (storeResults.Count() == 0)
                    {
                        using (StreamReader read = new StreamReader(emailTemplate))
                        {
                            message = read.ReadToEnd();
                        }
                        message = message.Replace("$$StoreName$$", stores[s].Name);
                        message = message.Replace("$$Details$$", "No records were found for " + stores[s].Name + ".  Please contact" +
                            " your OTM to verfiy correct settings");

                        //send mail message
                        var sendAddress = stores[s].Email;
                        Contact.ScheduledEmail(sendAddress, message);                      
                    }
                    
                    if (storeResults.Count() != 0)
                    {

                        using (StreamReader read = new StreamReader(emailTemplate))
                        {
                            message = read.ReadToEnd();
                        }
                        message = message.Replace("$$StoreName$$", stores[s].Name);
                        using (StreamReader read = new StreamReader("C:\\Users\\Jennifer\\Desktop\\MaintenanceTracking\\Maintenance.Utilities\\Email_Template\\TempInfo.txt"))//todo
                        {
                            //get temp info container and setup html table
                            var body = read.ReadToEnd();
                            var htmlTableStart = "<table style=\"border:1px solid black;\">";
                            var htmlTableEnd = "</table>";
                            var htmlTableTrStart = "<tr style=\"background-color: light gray\">";
                            var htmlTableTrEnd = "</tr>";
                            var htmlTableTdStart = "<td>";
                            var htmlTableTdEnd = "</td>";
                            var htmlTableThStart = "<th>";
                            var htmlTableThEnd = "</th>";
                            body += htmlTableStart;
                            body += htmlTableThStart + "Name" + htmlTableThEnd;
                            body += htmlTableThStart + "First Shot" + htmlTableThEnd;
                            body += htmlTableThStart + "Second Shot" + htmlTableThEnd;
                            //loop through data set
                            for (var a = 0; a < storeResults.Count(); a++)
                            {
                                var shortDate = "";
                                var firstShot = storeResults[a].FirstShot.ToString();
                                //check for null firstShot
                                if (storeResults[a].FirstShot == null)
                                {
                                    shortDate = "No First Shot Record";
                                }
                                else
                                {
                                    shortDate = DateTime.Parse(firstShot).ToString("dd, MMM, yyyy");
                                }
                                //generate table data
                                    body += htmlTableTrStart;
                                    body += htmlTableTdStart + storeResults[a].Name + htmlTableTdEnd;
                                    body += htmlTableTdStart + shortDate + htmlTableTdEnd;
                                    body += htmlTableTrEnd;

                            }
                            body += htmlTableEnd;
                            message = message.Replace("$$Details$$", body);

                        }
                        //send mail
                        var sendAddress = stores[s].Email;
                        Contact.ScheduledEmail(sendAddress, message);
                    }
                }
                //send supervisor report
                //get sup template
                var supTemplate = "C:\\Users\\Jennifer\\Desktop\\MaintenanceTracking\\Maintenance.Utilities\\Email_Template\\HepA_Sup_Template.html";//todo

                //get list of supervisors
                var supList = HepATask.SupervisorList();
                foreach (var item in supList)
                {
                    var supHepAData = HepATask.SupervisorReport(item.id);
                    if (supHepAData.Count() == 0)
                    {
                        using (StreamReader read = new StreamReader(supTemplate))
                        {
                            message = read.ReadToEnd();
                        }
                        message = message.Replace("$$Supervisor$$", item.name);
                        message = message.Replace("$$Details$$", "No records were found for your stores.  Please contact" +
                            " your OTM to verfiy correct settings");

                        //send mail message
                        var sendAddress = item.Email;
                        Contact.ScheduledEmail(sendAddress, message);
                    }

                    if (supHepAData.Count != 0)
                    {
                        using (StreamReader read = new StreamReader(supTemplate))
                        {
                            message = read.ReadToEnd();
                        }
                        message = message.Replace("$$Supervisor$$", item.name);
                        using (StreamReader read = new StreamReader("C:\\Users\\Jennifer\\Desktop\\MaintenanceTracking\\Maintenance.Utilities\\Email_Template\\TempInfo.txt"))//todo
                        {
                            //get temp info container and setup html table
                            var body = read.ReadToEnd();
                            var htmlTableStart = "<table style=\"border:1px solid black;\">";
                            var htmlTableEnd = "</table>";
                            var htmlTableTrStart = "<tr style=\"background-color: light gray\">";
                            var htmlTableTrEnd = "</tr>";
                            var htmlTableTdStart = "<td>";
                            var htmlTableTdEnd = "</td>";
                            var htmlTableThStart = "<th>";
                            var htmlTableThEnd = "</th>";
                            body += htmlTableStart;
                            body += htmlTableThStart + "Name" + htmlTableThEnd;
                            body += htmlTableThStart + "First Shot" + htmlTableThEnd;
                            body += htmlTableThStart + "Second Shot" + htmlTableThEnd;
                            //loop through data set
                            foreach (var data in supHepAData)
                            {
                                var shortDate = "";
                                var firstShot = data.FirstShot.ToString();
                                //check for null firstShot
                                if (data.FirstShot == null)
                                {
                                    shortDate = "No First Shot Record";
                                }
                                else
                                {
                                    shortDate = DateTime.Parse(firstShot).ToString("dd, MMM, yyyy");
                                }
                                //generate table data
                                body += htmlTableTrStart;
                                body += htmlTableTdStart + data.Name + htmlTableTdEnd;
                                body += htmlTableTdStart + shortDate + htmlTableTdEnd;
                                body += htmlTableTrEnd;

                            }
                            body += htmlTableEnd;
                            message = message.Replace("$$Details$$", body);

                        }
                        //send mail
                        var sendAddress = item.Email;
                        Contact.ScheduledEmail(sendAddress, message);
                    }
                }
                
            }

            //Monthly ServSafe Reporting
            if (dayOfMonth == 1 || ConfigurationManager.AppSettings["Mode"] == "Test")
            {
                var ServSafeTemplate = "C:\\Users\\Jennifer\\Desktop\\MaintenanceTracking\\Maintenance.Utilities\\Email_Template\\ServSafe_Template.html";//todo
                var Stores = ServSafeManager.StoresList();
                foreach (var item in Stores)
                {
                    var ServSafeData = ServSafeManager.ServSafeReport(item.id);
                    if (ServSafeData.Count() == 0)
                    {
                        using (StreamReader read = new StreamReader(ServSafeTemplate))
                        {
                            message = read.ReadToEnd();
                        }
                        message = message.Replace("$$StoreName$$", item.Name);
                        message = message.Replace("$$Details$$", "No records were found for your stores.  Please contact" +
                            " your OTM to verfiy correct settings");

                        //send mail message
                        var sendAddress = item.Email;
                        Contact.ScheduledEmail(sendAddress, message);
                    }

                    if (ServSafeData.Count() != 0)
                    {
                        using (StreamReader read = new StreamReader(ServSafeTemplate))
                        {
                            message = read.ReadToEnd();
                        }
                        message = message.Replace("$$StoreName$$", item.Name);
                        using (StreamReader read = new StreamReader("C:\\Users\\Jennifer\\Desktop\\MaintenanceTracking\\Maintenance.Utilities\\Email_Template\\TempInfo.txt"))//todo
                        {
                            //get temp info container and setup html table
                            var body = read.ReadToEnd();
                            var htmlTableStart = "<table style=\"border:1px solid black;\">";
                            var htmlTableEnd = "</table>";
                            var htmlTableTrStart = "<tr style=\"background-color: light gray\">";
                            var htmlTableTrEnd = "</tr>";
                            var htmlTableTdStart = "<td>";
                            var htmlTableTdEnd = "</td>";
                            var htmlTableThStart = "<th>";
                            var htmlTableThEnd = "</th>";
                            body += htmlTableStart;
                            body += htmlTableThStart + "Name" + htmlTableThEnd;
                            body += htmlTableThStart + "First Shot" + htmlTableThEnd;
                            body += htmlTableThStart + "Second Shot" + htmlTableThEnd;
                            //loop through data set
                            foreach (var record in ServSafeData)
                            {
                                //generate table data
                                body += htmlTableTrStart;
                                body += htmlTableTdStart + record.Name + htmlTableTdEnd;
                                body += htmlTableTdStart + record.Expiration + htmlTableTdEnd;
                                body += htmlTableTrEnd;

                            }
                            body += htmlTableEnd;
                            message = message.Replace("$$Details$$", body);

                        }
                        //send mail
                        var sendAddress = item.Email;
                        Contact.ScheduledEmail(sendAddress, message);
                    }
                }

            }

            //Additional Features to be built if requested
            //Monthly repair reporting -- end of month
            //var month = DateTime.Now.ToString("MM");
            //var year = DateTime.Now.ToString("yyyy");
            //var lastDay = DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(month));
            //if (dayOfMonth == lastDay)
            //{

            //}

        }

    }

}


