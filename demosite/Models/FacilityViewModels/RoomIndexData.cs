using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demosite.Models.FacilityViewModels
{
    public class RoomIndexData
    {
        public IEnumerable<Room> Rooms { get; set; } 
        public IEnumerable<Floor> Floors { get; set; }
        public IEnumerable<Building> Buildings { get; set; }
        public IEnumerable<Person> People { get; set; }

    }
}
