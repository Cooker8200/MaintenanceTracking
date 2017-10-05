using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Models
{
    public class MaintenanceLog
    {
            [Key]
            public int Id { get; set; }
            [Display(Name = "Store")]
            public int StoreId { get; set; }
            [Display(Name = "Serivce Date")]
            public DateTime ServiceDate { get; set; }
            [Display(Name = "Vendor")]
            public string VendorName { get; set; }
            [Display(Name = "Invoice")]
            public int Invoice { get; set; }
            [Display(Name = "Repair Detail")]
            public string RepairDetail { get; set; }
            [Display(Name = "Repair Type")]
            public string RepairType { get; set; }
            [Display(Name = "Store Name")]
            public string StoreName { get; set; }
    }
}
