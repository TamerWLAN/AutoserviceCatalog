using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_TO.model
{
    class CarList
    {
        public int CarListId { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public string AutoType { get; set; }
        public string VIN { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public DateTime? DateOfDeregistration { get; set; }
        public DateTime? LastToDate { get; set; }
        public int CurrentTraveled { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }

        public CarList()
        {
           Maintenances = new List<Maintenance>();
        }
    }
}
