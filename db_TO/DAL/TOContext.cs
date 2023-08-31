using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using db_TO.model;

namespace db_TO.DAL
{
    class TOContext : DbContext
    {
        public TOContext() : base("To")
        {
            Database.SetInitializer(new TOInitializer());
        }
        public DbSet<Mark> MarkDb { get; set; }
        public DbSet<Model> ModelDb { get; set; }
        public DbSet<CarList> CarListDb { get; set; }
        public DbSet<Maintenance> MaintenanceDb { get; set; }
        public DbSet<WorkType> WorkTypesDb { get; set; }
        public DbSet<Works> WorkDb { get; set; }
        public DbSet<Employees> EmployeesDb { get; set; }
        public DbSet<SpareParts> SparePartsDb { get; set; }
    }
}
