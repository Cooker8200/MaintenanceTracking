using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Models
{
    public class StoreList
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }
    }
}
