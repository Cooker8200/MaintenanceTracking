using Maintenance.Business;
using System;
using System.Collections;
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

        // !!! Descrition tag helper --- No longer needed !!!
        //public static string GetDescription(Enum en)  //todo
        //{
        //    Type type = en.GetType();
        //    MemberInfo[] memInfo = type.GetMember(en.ToString());

        //    if (memInfo != null && memInfo.Length > 0)
        //    {
        //        object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

        //        if (attrs != null && attrs.Length > 0)
        //        {
        //            return ((DescriptionAttribute)attrs[0]).Description;
        //        }
        //    }

        //    return en.ToString();
        //}

        public ActionResult OtpRequest()
        {
            List<SelectListItem> SendTo = new List<SelectListItem>();
            SendTo.Add(new SelectListItem { Text = "Test", Value = "Cooker8200@hotmail.com" });
            SendTo.Add(new SelectListItem { Text = "University City", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "Ballwin", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "Dorsett", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "Ashby", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "Lindell", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "Olivette", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "Clarkson", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "141", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "Overland Plaza", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "Howdershell", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "Earth City", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "Creve Coeur", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "St John's", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "Ellisville", Value = "@us.stores.mcd.com" });
            SendTo.Add(new SelectListItem { Text = "Office", Value = "@us.stores.mcd.com" });
            ViewBag.SendTo = SendTo;
            Session["StoreName"] = SendTo;

            List<SelectListItem> Equipment = new List<SelectListItem>();
            Equipment.Add(new SelectListItem { Text = "POS", Value = "POS" });
            Equipment.Add(new SelectListItem { Text = "Register", Value = "Register" });
            Equipment.Add(new SelectListItem { Text = "KVS Controller", Value = "KVS Controller" });
            Equipment.Add(new SelectListItem { Text = "POS Server", Value = "POS Server" });
            Equipment.Add(new SelectListItem { Text = "ISP Server", Value = "ISP Server" });
            Equipment.Add(new SelectListItem { Text = "Printer", Value = "Printer" });
            Equipment.Add(new SelectListItem { Text = "Bumpbar", Value = "Bumpbar" });
            Equipment.Add(new SelectListItem { Text = "Kiosk", Value = "Kiosk" });
            Equipment.Add(new SelectListItem { Text = "Tablet", Value = "Tablet" });
            ViewBag.Equipment = Equipment;

            List<SelectListItem> Location = new List<SelectListItem>();
            Location.Add(new SelectListItem { Text = "Front Counter", Value = "Front Counter" });
            Location.Add(new SelectListItem { Text = "Present Booth", Value = "Present Booth" });
            Location.Add(new SelectListItem { Text = "Cash Booth", Value = "Cash Booth" });
            Location.Add(new SelectListItem { Text = "CBB Cell", Value = "CBB Cell" });
            Location.Add(new SelectListItem { Text = "Grill Area", Value = "Grill Area" });
            Location.Add(new SelectListItem { Text = "Office", Value = "Office" });
            Location.Add(new SelectListItem { Text = "Tech Closet", Value = "Tech Closet" });
            Location.Add(new SelectListItem { Text = "Lobby", Value = "Lobby" });
            ViewBag.Location = Location;

            // !!! Old code for enumerable drop down !!!
            //Maintenance.Models.OtpRequest model = new Maintenance.Models.OtpRequest();
            //IEnumerable<Maintenance.Models.Store> Store = Enum.GetValues(typeof(Maintenance.Models.Store)).Cast<Maintenance.Models.Store>();
            //model.Store = from name in Store
            //              select new SelectListItem
            //              {

            //                  Text = name.ToString(),                    //todo implement desctiption tags
            //                  //Text = GetDescription(),
            //                  Value = ((int)name).ToString()
            //              };
            //IEnumerable<Maintenance.Models.Equipment> Equipment = Enum.GetValues(typeof(Maintenance.Models.Equipment)).Cast<Maintenance.Models.Equipment>();
            //model.Equipment = from equipment in Equipment
            //                  select new SelectListItem
            //                  {
            //                      Text = equipment.ToString(),
            //                      Value = ((int)equipment).ToString()

            //                  };
            //IEnumerable<Maintenance.Models.Location> Location = Enum.GetValues(typeof(Maintenance.Models.Location)).Cast<Maintenance.Models.Location>();
            //model.Location = from location in Location
            //                 select new SelectListItem
            //                 {
            //                     Text = location.ToString(),
            //                     Value = ((int)location).ToString()

            //                 };

            return View();
        }

        public ActionResult Sent()
        {
            return View();
        }


        public ActionResult SendOtp (string SendTo, string Name, string Equipment, string Location, string Problem)
        {
            var stores = (List<SelectListItem>)Session["StoreName"];
            var store = stores.FirstOrDefault(x => x.Value == SendTo);
            var storeName = store.Text;

            _contact.SendOtp(SendTo, Name, Equipment, Location, Problem, storeName);

            return View("Sent");
        }
        //public ActionResult SendOtp(Maintenance.Models.OtpRequest model, string SendTo)
        //{
            
        //    if (ModelState.IsValid)
        //    {
        //        _contact.SendOtp(model);
        //    }
        //    else
        //    {
        //        return View("OtpRequest");
        //    }
        //    return View("Sent");
        //}
    }
}