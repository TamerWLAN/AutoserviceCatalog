using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_TO.model
{
    class Works
    {
        public int WorksId { get; set; }
        public int WorkTypeId { get; set; }
        public WorkType WorkType { get; set; }
        public int MaintenanceId { get; set; }
        public Maintenance Maintenance{ get; set; }
        public int FactTime { get; set; }
        public int Cost { get; set; }
        public int CountOfSparePart { get; set; }
        public int EmployeesId { get; set; }
        public Employees Employees { get; set; }
        public virtual ICollection<SpareParts> SparePartses { get; set; }

        public Works()
        {
            SparePartses = new List<SpareParts>();
        }
    }
}
