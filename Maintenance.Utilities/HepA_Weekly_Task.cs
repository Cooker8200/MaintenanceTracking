using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maintenance.Data;
using Maintenance.Data.DataAccess;
using System.Net.Mail;
using System.Net;

namespace Maintenance.Utilities
{
    public class HepA_Weekly_Task
    {
        public static void Main(string[] args)
        {
            int[] results = new int[] { 1, 2, 3, 4 };
        

            var mail = new MailMessage();
            mail.Body = results.ToString();
            mail.From = new MailAddress("mcd_developer@hotmail.com");
            mail.To.Add(new MailAddress("Cooker8200@hotmail.com"));
            mail.Subject = "Hello";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp-mail.outlook.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("mcd_developer@hotmail.com", "mcdDeveloper1234");
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }

    }
}

