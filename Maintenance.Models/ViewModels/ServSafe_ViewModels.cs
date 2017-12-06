﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Models.ViewModels
{
    public class ServSafe_ViewModels
    {
        public string Name { get; set; }

        public string Proctor { get; set; }
        [DataType(DataType.Date)]
        public DateTime Expiration { get; set; }
    }
}
