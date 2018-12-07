using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using demosite.Models;

namespace demosite.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly demosite.Models.demositeContext _context;

        public IndexModel(demosite.Models.demositeContext context)
        {
            _context = context;
        }
        public string RoomIDSort { get; set; }
        public string RoomNameSort { get; set; }
        public string FloorNameSort { get; set; }
        public string BNameSort { get; set; }
        public string BAddressSort { get; set; }
       

        public IList<Room> Room { get;set; }
        public int RoomID { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            RoomIDSort = String.IsNullOrEmpty(sortOrder) ? "roomid_desc" : "";
            RoomNameSort = sortOrder == "RoomName" ? "roomname_desc" : "RoomName";
            FloorNameSort = sortOrder == "FloorName" ? "floorname_desc" : "FloorName";
            BNameSort = sortOrder == "BName" ? "bname_desc" : "BName";
            BAddressSort = sortOrder == "BAddress" ? "baddress_desc" : "BAddress";

            IQueryable<Room> roomIQ = from r in _context.Room
                                      select r;
            switch (sortOrder)
            {
                case "roomid_desc":
                    roomIQ = roomIQ.OrderByDescending(r => r.RoomID);
                    break;
                case "RoomName":
                    roomIQ = roomIQ.OrderBy(r => r.RoomName);
                    break;
                case "roomname_desc":
                    roomIQ = roomIQ.OrderByDescending(r => r.RoomName);
                    break;
                case "FloorName":
                    roomIQ = roomIQ.OrderBy(r => r.Floor.FloorName);
                    break;
                case "floorname_desc":
                    roomIQ = roomIQ.OrderByDescending(r => r.Floor.FloorName);
                    break;
                case "BName":
                    roomIQ = roomIQ.OrderBy(r => r.Floor.Building.BName);
                    break;
                case "bname_desc":
                    roomIQ = roomIQ.OrderByDescending(r => r.Floor.Building.BName);
                    break;
                case "BAddress":
                    roomIQ = roomIQ.OrderBy(r => r.Floor.Building.BAddress);
                    break;
                case "baddress_desc":
                    roomIQ = roomIQ.OrderByDescending(r => r.Floor.Building.BAddress);
                    break;
                default:
                    roomIQ = roomIQ.OrderBy(r => r.RoomID);
                    break;
            }
            Room = await roomIQ.AsNoTracking()
                .Include(r => r.Floor)
                .Include(r => r.Floor.Building)
                .Include(r => r.Floor.Building.PersonsBuildings)
                .ToListAsync();
        }
    }
}
