using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_TO.model
{
    class Maintenance
    {
        public int MaintenanceId { get; set; }
        public int CarListId { get; set; }
        public CarList CarList { get; set; }
        public DateTime Date { get; set; }
        public int Traveled { get; set; }
        public ICollection<Works> Workses { get; set; }

        public Maintenance()
        {
            Workses = new List<Works>();
        }
    }
}
