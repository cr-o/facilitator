using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace demosite.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        [Required]
        public string RoomName { get; set; }
        [Required]
        public int FloorID { get; set; }
        [Required]
        public Floor Floor { get; set; }    //1:n
    }
}
