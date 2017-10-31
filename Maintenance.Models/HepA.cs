using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Models
{
    public class HepA
    {
        [Key]
        public int Id { get; set; }

        public string EmpName { get; set; }

        public DateTime? FirstShot { get; set; }

        public DateTime? SecondShot { get; set; }

        public string Store { get; set; }




    }
}
