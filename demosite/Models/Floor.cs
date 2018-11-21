using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demosite.Models
{
    public class Floor
    {
        public int FloorID { get; set; }
        public string FloorName { get; set; }
        public int BuildingID { get; set; }
        public Building Building { get; set; }
        public ICollection<Room> Rooms { get; set; }    //1:n
    }
}
