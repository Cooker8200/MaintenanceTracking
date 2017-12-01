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

        public DbSet<HepA> HepA { get; set; }

        public DbSet<ServSafe> ServSafe { get; set; }

        public DbSet<Stores> Stores { get; set; }

        public DbSet<Employees> Employees { get; set; }
    }
}
