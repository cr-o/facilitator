
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace demosite.Models
{
    public class PersonsBuilding
    {
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public int BuildingID { get; set; }
        public Building Building { get; set; }
    }
}
