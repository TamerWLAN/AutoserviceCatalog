using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_TO.model
{
    class Model
    {
        public int ModelId { get; set; }
        public int MarkId { get; set; }
        public Mark Mark { get; set; }
        public string ModelName { get; set; }
        public virtual ICollection<CarList> CarLists { get; set; }

        public Model()
        {
            CarLists = new List<CarList>();
        }
    }

}
