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

namespace Maintenance.Utilities
{
    public class HepA_Weekly_Task
    {
        public static void Main(string[] args)
        {
            var HepATask = new HepAManager();

            var records = HepATask.WeeklyReport();

            //create file and write records results to file, then read file to compile message
            var message = "";
            var date = DateTime.Now.ToString("dd-MMM-yyyy");
            var fileName = date + " Weekly HepA.txt";
            var path = Path.Combine("C:\\Users\\Jennifer\\Desktop\\MaintenanceTracking\\Maintenance.Utilities\\WeeklyHepA_Report", fileName);
            FileStream file = File.Create(path);

            using (StreamWriter write = new StreamWriter(file))
            {
                write.WriteLine(DateTime.Now.ToString("dd-MMM-yyyy"));
                foreach (HepA item in records)
                {
                    if (item.FirstShot > DateTime.Now)
                    {
                        write.WriteLine(item.EmpName + " has invalid shot information.  Please check and update database");
                    }
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
                            var empGood = item.EmpName + " has " + time + " months left to get second HepA shot";
                            write.WriteLine(empGood + " -- First Shot: " + writeFirstShot);  
                        }
                        if (time <= 1 && time > 0)
                        {
                            var empBad = item.EmpName + " has less than 30 days to get second HepA shot";
                            write.WriteLine(empBad + " -- First Shot: " + writeFirstShot);
                        }
                        if (time <= 0)
                        {
                            var offSch = item.EmpName + " MUST NOT WORK UNTIL SECOND HEP A SHOT!!";
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
                            var empGood = item.EmpName + " has " + lateTime + " months left to get second HepA shot";
                            write.WriteLine(empGood + " -- First Shot: " + writeFirstShot);
                        }
                        if (lateTime <= 1 && lateTime > 0)
                        {
                            var empBad = item.EmpName + " has less than 30 days to get second HepA shot";
                            write.WriteLine(empBad + " -- First Shot: " + writeFirstShot);
                        }
                        if (lateTime <= 0)
                        {
                            var offSch = item.EmpName + " MUST NOT WORK UNTIL SECOND HEP A SHOT!!";
                            write.WriteLine(offSch + " -- First Shot: " + writeFirstShot);
                        }
                    }
                }
            }

            using (StreamReader read = new StreamReader(path))
            {
                message = read.ReadToEnd();
            }

            //send mail message with results of weekly search
            var port = Convert.ToInt32(ConfigurationSettings.AppSettings["Email.Port"]);
            var mail = new MailMessage();
            mail.Body = message;
            mail.From = new MailAddress(ConfigurationSettings.AppSettings["Email.From"]);
            mail.To.Add(new MailAddress(ConfigurationSettings.AppSettings["Email.SendTo"]));
            //option cc email address
            //mail.CC.Add(new MailAddress(" "));
            mail.Subject = "Weekly Hep A  " + DateTime.Now.ToString("dd-MM-yyyy");
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationSettings.AppSettings["Email.Host"];
            smtp.Port = port;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(ConfigurationSettings.AppSettings["Email.User"], ConfigurationSettings.AppSettings["Email.Password"]);
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }

    }
}

