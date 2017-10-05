using Maintenance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Business
{
    public class ContactManager
    {
        public void SendOtp(Maintenance.Models.OtpRequest model)
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            var store = ((Store)Enum.ToObject(typeof(Store), model.StoreId)).ToString();
            var location = ((Location)Enum.ToObject(typeof(Location), model.LocationId)).ToString();
            var equipment = ((Equipment)Enum.ToObject(typeof(Equipment), model.EquipmentId)).ToString();
            message.To.Add(new MailAddress("Cooker8200@hotmail.com"));
            message.CC.Add(new MailAddress("mcook.banducci@outlook.com"));  //could change to office email in live
            message.From = new MailAddress("mcd_developer@outlook.com");
            message.Subject = string.Format(store + " " + "OTP Request");
            message.Body = string.Format(body, store, model.Name, "Issue at " + location + " with " + equipment + " ... Brief Description: " + model.Problem);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "mcd_developer@outlook.com",
                    Password = "mcdDeveloper1234"
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }

        }
    }
}
