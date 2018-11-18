using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demosite.Models
{
    public class Facility
    {
        public int ID { get; set; }
        [RegularExpression(@"^[a-zA-Z ]+$")]
        [Required]
 
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
    }
}
