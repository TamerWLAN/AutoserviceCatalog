using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_TO.model
{
    class SpareParts
    {
        public int SparePartsId { get; set; }
        public string ParName { get; set; }
        public string Units { get; set; }
        public int Cur_Count { get; set; }
        public virtual ICollection<Works> Workses { get; set; }
        public SpareParts()
        {
            Workses = new List<Works>();
        }
    }
}
