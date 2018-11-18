using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using demosite.Models;

namespace demosite.Pages.Facilities
{
    public class DetailsModel : PageModel
    {
        private readonly demosite.Models.demositeContext _context;

        public DetailsModel(demosite.Models.demositeContext context)
        {
            _context = context;
        }

        public Facilities Facility { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Facility = await _context.Facility.FirstOrDefaultAsync(m => m.ID == id);

            if (Facility == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
