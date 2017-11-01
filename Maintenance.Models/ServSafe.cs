using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Models
{
    public class ServSafe
    {
        [Key]
        public int Id { get; set; }

        public string EmpName { get; set; }

        public string Proctor { get; set; }
        [DataType(DataType.Date)]
        public DateTime Expiration { get; set; }

        public string Store { get; set; }
    }
}
