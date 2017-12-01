using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Models
{
    public class Employees
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public int StoreId { get; set; }
    }
}
