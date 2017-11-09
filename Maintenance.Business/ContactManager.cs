using Maintenance.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Maintenance.Business
{
    public class ContactManager
    {

        public void SendOtp(string SendTo, string Name, string Equipment, string Location, string Problem, string StoreName)
        {
            //create email template
            string email;
            var emailFilePath = HttpContext.Current.Server.MapPath("~/Templates/Contact_Template.html");       //todo fix file mapping issue
            //var emailFilePath = ("~/Email_Template/Contact_Template.html");
            //var emailFilePath = ("C:/Users/Jennifer/Desktop/MaintenanceTracking/Maintenance.Business/Email_Template/Contact_Template.html");
            using (var streamReader = new StreamReader(emailFilePath))
            {
                email = streamReader.ReadToEnd();
            }
            //replace template values with form submission
            email = email.Replace("$$Store$$", StoreName);
            email = email.Replace("$$Equipment$$", Equipment);
            email = email.Replace("$$Location$$", Location);
            email = email.Replace("$$Problem$$", Problem);
            //generate email
            try
            {
                //todo fix webconfig errors
                var port = Convert.ToInt32(ConfigurationSettings.AppSettings["Email.Port"]);
                var body = email;
                //var body = "<p>Support Request From: {0}, {1}</p><p>Problem: {4}</p><p>{2} at {3}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("Cooker8200@hotmail.com"));
                //message.To.Add(new MailAddress(ConfigurationSettings.AppSettings["Email.SendTo"]));      //change to SendTo upon deployment
                //message.CC.Add(new MailAddress(ConfigurationSettings.AppSettings[" "]));               //could change to office email in live
                message.From = new MailAddress("mcd_developer@outlook.com");
                //message.From = new MailAddress(ConfigurationSettings.AppSettings["Email.User"]);
                message.Subject = string.Format("OTP Request");
                message.Body = body;
                //message.Body = string.Format(body, SendTo, Name, Equipment, Location, Problem);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "mcd_developer@outlook.com",
                        Password = "mcdDeveloper1234"
                        //UserName = ConfigurationSettings.AppSettings["Email.User"],
                        //Password = ConfigurationSettings.AppSettings["Email.Password"]
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    //smtp.Host = ConfigurationManager.AppSettings["Email.Host"];
                    smtp.Port = 587;
                    //smtp.Port = port;
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }



        }

        // !!! Old Contact Form !!!
        //public void SendOtp(Maintenance.Models.OtpRequest model)
        //{
        //    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
        //    var message = new MailMessage();
        //    var store = 1;
        //    //var store = ((Store)Enum.ToObject(typeof(Store), model.StoreId)).ToString();
        //    //var location = ((Location)Enum.ToObject(typeof(Location), model.LocationId)).ToString();
        //    //var equipment = ((Equipment)Enum.ToObject(typeof(Equipment), model.EquipmentId)).ToString();
        //    message.To.Add(new MailAddress(" "));
        //    message.CC.Add(new MailAddress(" "));  //could change to office email in live
        //    message.From = new MailAddress(" ");
        //    message.Subject = string.Format(store + " " + "OTP Request");
        //    //message.Body = string.Format(body, store, model.Name, "Issue at " + location + " with " + equipment + " ... Brief Description: " + model.Problem);
        //    message.IsBodyHtml = true;

        //    using (var smtp = new SmtpClient())
        //    {
        //        var credential = new NetworkCredential
        //        {
        //            UserName = " ",
        //            Password = " "
        //        };
        //        smtp.Credentials = credential;
        //        smtp.Host = "smtp-mail.outlook.com";
        //        smtp.Port = 587;
        //        smtp.EnableSsl = true;
        //        smtp.Send(message);
        //    }

        //}
    }
}
