using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using demosite.Models;

namespace demosite.Pages.Rooms
{
    public class CreateModel : PageModel
    {
        private readonly demosite.Models.demositeContext _context;

        public CreateModel(demosite.Models.demositeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FloorID"] = new SelectList(_context.Floor, "FloorID", "FloorID");
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

            _context.Room.Add(Room);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}