using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demosite.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomID { get; set; }
        [Required]
        public string RoomName { get; set; }
        [Required]
        public int FloorID { get; set; }
        public Floor Floor { get; set; }    //1:n
    }
}
