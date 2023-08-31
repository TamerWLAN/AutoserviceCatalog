using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_TO.model
{
    class Employees
    {
        public int EmployeesId { get; set; }
        public string PostName { get; set; }
        public DateTime HireDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Works> Workses { get; set; }
        public Employees()
        {
            Workses = new List<Works>();
        }
    }
}
