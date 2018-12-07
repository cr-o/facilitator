using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demosite.Models;

namespace demosite.Pages.Rooms
{
    public class EditModel : prepopulatebasePageModel
    {
        private readonly demosite.Models.demositeContext _context;

        public EditModel(demosite.Models.demositeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Room Room { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await _context.Room
                .Include(r => r.Floor)
                .FirstOrDefaultAsync(m => m.RoomID == id);

            if (Room == null)
            {
                return NotFound();
            }
            PopulateDropDownList(_context, Room.FloorID);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int personI)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var roomToUpdate = await _context.Room.FindAsync(id);
            if (await TryUpdateModelAsync<Room>(
                 roomToUpdate,
                 "room",
                   r => r.RoomID, r => r.FloorID, r => r.RoomName))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


            PopulateDropDownList(_context, roomToUpdate.FloorID);
            return Page();
        }
    }
}
