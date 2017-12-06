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

        [DataType(DataType.Date)]
        public DateTime? FirstShot { get; set; }
        [DataType(DataType.Date)]
        public DateTime? SecondShot { get; set; }

        public int EmpId { get; set; }

        public string Store { get; set; }




    }
}
