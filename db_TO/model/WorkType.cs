using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_TO.model
{
    class WorkType
    {
        public int WorkTypeId { get; set; }
        public string WorkTypeName { get; set;}
        public int NormTime { get; set; }
        public ICollection<Works> Workses { get; set; }

        public WorkType()
        {
            Workses = new List<Works>();
        }
    }
}
