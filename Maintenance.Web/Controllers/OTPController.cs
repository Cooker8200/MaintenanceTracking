using Maintenance.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Maintenance.Web.Controllers
{
    public class OTPController : Controller
    {
        public OTPController()
        {
            _contact = new ContactManager();
        }

        private ContactManager _contact;

        public static string GetDescription(Enum en)  //todo
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }

        public ActionResult OtpRequest()
        {
            Maintenance.Models.OtpRequest model = new Maintenance.Models.OtpRequest();
            IEnumerable<Maintenance.Models.Store> Store = Enum.GetValues(typeof(Maintenance.Models.Store)).Cast<Maintenance.Models.Store>();
            model.Store = from name in Store
                          select new SelectListItem
                          {

                              Text = name.ToString(),                    //todo implement desctiption tags
                              //Text = GetDescription(),
                              Value = ((int)name).ToString()
                          };
            IEnumerable<Maintenance.Models.Equipment> Equipment = Enum.GetValues(typeof(Maintenance.Models.Equipment)).Cast<Maintenance.Models.Equipment>();
            model.Equipment = from equipment in Equipment
                              select new SelectListItem
                              {
                                  Text = equipment.ToString(),
                                  Value = ((int)equipment).ToString()

                              };
            IEnumerable<Maintenance.Models.Location> Location = Enum.GetValues(typeof(Maintenance.Models.Location)).Cast<Maintenance.Models.Location>();
            model.Location = from location in Location
                             select new SelectListItem
                             {
                                 Text = location.ToString(),
                                 Value = ((int)location).ToString()

                             };
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }

        public ActionResult SendOtp(Maintenance.Models.OtpRequest model)
        {
            if (ModelState.IsValid)
            {
                _contact.SendOtp(model);
            }
            else
            {
                return View("OtpRequest");
            }
            return View("Sent");
        }
    }
}