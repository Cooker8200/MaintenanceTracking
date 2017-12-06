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

        public int? StoreNumber { get; set; }

        public string Address { get; set; }

        public int? Phone { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int? ZipCode { get; set; }

        public int? Supervisor { get; set; }

        public int? Otp { get; set; }

    }
}
