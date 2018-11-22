using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demosite.Models
{
    public class Facility
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [RegularExpression(@"^[a-zA-Z ]+$")]
        [Required]
 
        public string People { get; set; }
        public string Buildings { get; set; }
        public string Floors { get; set; }
        public string Rooms { get; set; }
        //all these will be icollections
        //public ICollection<PersonsBuilding> PersonsBuildings { get; set; } //many to many
    }
}
