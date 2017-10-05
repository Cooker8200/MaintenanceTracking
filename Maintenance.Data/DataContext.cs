using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Maintenance.Models;

namespace Maintenance.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=LogAccess")
        {

        }

        public DbSet<MaintenanceLog> MaintenanceLog { get; set; }
    }
}
