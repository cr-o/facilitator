using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace demosite.Models
{
    public class PersonsBuilding
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public int BuildingID { get; set; }
        public Building Building { get; set; }
    }
}
