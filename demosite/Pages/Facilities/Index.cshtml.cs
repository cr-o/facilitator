using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using demosite.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace demosite.Pages.Facilities
{
    public class IndexModel : PageModel
    {
        private readonly demosite.Models.demositeContext _context;

        public IndexModel(demosite.Models.demositeContext context)
        {
            _context = context;
        }

        public IList<Facility> Facility { get;set; }
        public string SearchString { get; set; }
        public int Room { get; set; }
        public string FacilityRoom { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            var facilities = from f in _context.Facility
                         select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                facilities = facilities.Where(s => s.People.Contains(searchString));
            }

            Facility = await facilities.ToListAsync();
            SearchString = searchString;
        }
    }
}
