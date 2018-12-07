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
    public class CreateModel : prepopulatebasePageModel
    {
        private readonly demosite.Models.demositeContext _context;

        public CreateModel(demosite.Models.demositeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Room Room { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var emptyRoom = new Room();
            
                if (await TryUpdateModelAsync<Room>(
                    emptyRoom,
                    "room",
                    r => r.RoomID, r => r.FloorID, r => r.RoomName))
                {
                var existCount = _context.Room.Count(r => r.RoomID == Room.RoomID);
                if (existCount == 0)
                {
                    _context.Room.Add(emptyRoom);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }

                }
            
            PopulateDropDownList(_context, emptyRoom.FloorID);
            return Page();
        }
    }
}
