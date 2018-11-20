using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace demosite.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        [RegularExpression(@"^[a-zA-Z ]+$")]
        [Required]
        public string Fname { get; set; }
        [RegularExpression(@"^[a-zA-Z ]+$")]
        [Required]
        public string LName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<PersonsBuilding> PersonsBuildings { get; set; }

    }
}
