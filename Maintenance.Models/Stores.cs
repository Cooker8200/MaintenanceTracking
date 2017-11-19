using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Maintenance.Models
{
    public class Stores
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }
        //public Stores()
        //{
        //    StoreList = new List<SelectListItem>();
        //}

        //public IEnumerable<SelectListItem> StoreList { get; set; }
        //[Display(Name = "University City")]
        //public string UniversityCity {get;set;}
        //[Display(Name = "Ballwin")]
        //public string Ballwin { get; set; }
        //[Display (Name = "Dorsett")]
        //public string Dorsett { get; set; }
        //[Display (Name = "Ashby")]
        //public string Ashby { get; set; }
        //[Display (Name = "Lindell")]
        //public string Lindell { get; set; }
        //[Display (Name = "Olivette")]
        //public string Olivette { get; set; }
        //[Display (Name = "Clarkson")]
        //public string Clarkson { get; set; }
        //[Display (Name = "141")]
        //public string OneFortyOne { get; set; }
        //[Display (Name = "Overland Plaza")]
        //public string OverlandPlaza { get; set; }
        //[Display (Name = "Howdershell")]
        //public string Howdershell { get; set; }
        //[Display (Name = "Earth City")]
        //public string EarthCity { get; set; }
        //[Display(Name = "Creve Coeur")]
        //public string CreveCoeur { get; set; }
        //[Display (Name = "St. John")]
        //public string StJohn { get; set; }
        //[Display (Name = "Ellisville")]
        //public string Ellisville { get; set; }
        //[Display (Name = "Office")]
        //public string Office { get; set; }
    }
}
