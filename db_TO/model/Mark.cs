using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_TO.model
{
    class Mark
    {
        public int MarkId { get; set; }
        public string MarkName { get; set; }
        public virtual ICollection<Model> Models { get; set; }
        public Mark()
        {
            Models = new List<Model>();
        }
    }
}
