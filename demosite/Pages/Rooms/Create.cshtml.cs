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
            //ViewData["FloorID"] = new SelectList(_context.Floor, "FloorID", "FloorID");
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
            
            //_context.Room.Add(Room);
            //await _context.SaveChangesAsync();
            PopulateDropDownList(_context, emptyRoom.FloorID);
            return Page();
        }
    }
}
    /*
    Room = await _context.Room
        .Include(r => r.Floor)
        .Include(r => r.Floor.Building)
        .Include(r => r.Floor.Building.PersonsBuildings)
            .ThenInclude(r => r.Person)
        .FirstOrDefaultAsync(m => m.RoomID == id);
        */
    /*
                var parent = new Building
                {
                    Floors = new List<Floor>()
                };
                parent.Floors.Add(new Floor{
                    FloorID .fgdfgdfasd;

                    _context.Add(parent);
                     */
    //_context.SaveChanges();


    /*
    var entity = _context.Building
        .Include(b => b.Floors.Select(f => f.Rooms))
        .FirstOrDefaultAsync(b => b.BuildingID == Room.Floor.BuildingID);
        */
    /*
    Floor f = new Floor();
    f.Building = b;
    _context.Floor.Add(f);
    Room r = new Room();
    r.Floor = f;
    _context.Room.Add(r);
    */
    /*
    if (!ModelState.IsValid)
    {
        return Page();
    }

    //_context.Room.Add(Room);
    await _context.SaveChangesAsync();

    return RedirectToPage("./Index");
    */

/*
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
        //ViewData["FloorID"] = new SelectList(_context.Floor, "FloorID", "FloorID");
            return Page();
        }

        [BindProperty]
        public Room Rooms { get; set; }

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
                _context.Room.Add(emptyRoom);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");

            }

            //_context.Room.Add(Room);
            //await _context.SaveChangesAsync();
            PopulateDropDownList(_context, emptyRoom.FloorID);
            return Page();
        }
    }
}
*/
