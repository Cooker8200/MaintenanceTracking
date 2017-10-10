using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Maintenance.Models
{
    public class OtpRequest
    {
        public OtpRequest()
        {
            Store = new List<SelectListItem>();

            Equipment = new List<SelectListItem>();

            Location = new List<SelectListItem>();
        }

        public int StoreId { get; set; }
        public IEnumerable<SelectListItem> Store { get; set; }
        [Required]
        public string Name { get; set; }
        public int EquipmentId { get; set; }
        public IEnumerable<SelectListItem> Equipment { get; set; }
        public int LocationId { get; set; }
        public IEnumerable<SelectListItem> Location { get; set; }
        [Required]
        public string Problem { get; set; }
    }

    public enum Store
    {
        [Description("University City")]
        UniversityCity,
        [Description("Ballwin")]
        Ballwin,
        [Description("Drosett")]
        Dorsett,
        [Description("Ashby")]
        Ashby,
        [Description("Lindell")]
        Lindell,
        [Description("Olivette")]
        Olivette,
        [Description("Clarkson")]
        Clarkson,
        [Description("141")]
        onefortyone,
        [Description("Overland Plaza")]
        OverlandPlaza,
        [Description("Howdershell")]
        Howdershell,
        [Description("Earth Cirt")]
        EarthCity,
        [Description("Creve Coeur")]
        CreveCoeur,
        [Description("St. John")]
        StJohn,
        [Description("Ellisville")]
        Ellisville,
        [Description("Office")]
        Office

    }

    public enum Equipment
    {
        [Description("POS")]
        POS,
        [Description("Register")]
        Register,
        [Description("KVS Controller")]
        KvsController,
        [Description("POS Server")]
        PosServer,
        [Description("ISP Server")]
        IspServer,
        [Description("Printer")]
        Printer,
        [Description("BumpBar")]
        Bumpbar,
        [Description("Kiosk")]
        Kiosk,
        [Description("Tablet")]
        Tablet,

    }

    public enum Location
    {
        [Description("Front Counter")]
        FrontCounter,
        [Description("Present Booth")]
        PresentBooth,
        [Description("Cash Booth")]
        CashBooth,
        [Description("CBB Cell")]
        CbbCell,
        [Description("Grill Area")]
        GrillArea,
        [Description("Office")]
        Office,
        [Description("Tech Closet")]
        TechCloset,
        [Description("Lobby")]
        Lobby
    }
}

