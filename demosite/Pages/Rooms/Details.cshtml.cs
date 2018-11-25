using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using demosite.Models;
using demosite.Models.FacilityViewModels;

namespace demosite.Pages.Rooms
{
    public class DetailsModel : PageModel
    {
        private readonly demosite.Models.demositeContext _context;

        public DetailsModel(demosite.Models.demositeContext context)
        {
            _context = context;
        }

        public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? personID)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await _context.Room
                .Include(r => r.Floor)
                .Include(r => r.Floor.Building)
                .Include(r => r.Floor.Building.PersonsBuildings)
                    .ThenInclude(r => r.Person)
                .FirstOrDefaultAsync(m => m.RoomID == id);

            if (Room == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
