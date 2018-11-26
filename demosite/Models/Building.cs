using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace demosite.Models
{
    public class Building
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BuildingID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$")]
        public string BName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$")]
        public string BAddress { get; set; }
        public ICollection<Floor> Floors { get; set; }
        public IList<PersonsBuilding> PersonsBuildings { get; set; }
    }
}
