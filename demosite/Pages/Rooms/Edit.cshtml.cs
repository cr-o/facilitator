﻿using System;
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
    public class EditModel : PageModel
    {
        private readonly demosite.Models.demositeContext _context;

        public EditModel(demosite.Models.demositeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Room Room { get; set; }
        public int RoomID { get; set; }
        public Person Person { get; set; }
        public int PersonID { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id, int personID)
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
           ViewData["FloorID"] = new SelectList(_context.Floor, "FloorID", "FloorID");
           ViewData["BuildingID"] = new SelectList(_context.Building, "BuildingID", "BuildingID");
           ViewData["PersonID"] = new SelectList(_context.Person, "PersonID", "PersonID");

        
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int personI)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var roomToUpdate = await _context.Room
                .Include(r => r.Floor)
                .Include(r => r.Floor.Building)
                .Include(r => r.Floor.Building.PersonsBuildings)
                    .ThenInclude(r => r.Person)
                .FirstOrDefaultAsync(m => m.RoomID == id);
            _context.Attach(roomToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(Room.RoomID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.RoomID == id);
        }
    }
}
