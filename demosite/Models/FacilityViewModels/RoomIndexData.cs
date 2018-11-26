using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demosite.Models.FacilityViewModels
{
    public class RoomIndexData
    {
        public List<Room> Rooms { get; set; } 
        public List<Floor> Floors { get; set; }
        public List<Building> Buildings { get; set; }
        public List<Person> People { get; set; }

    }
}
