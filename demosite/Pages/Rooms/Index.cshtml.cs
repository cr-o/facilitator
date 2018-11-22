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

        public IList<Room> Room { get;set; }
        public int RoomID { get; set; }

        public async Task OnGetAsync()
        {
            Room = await _context.Room
                .Include(r => r.Floor)
                .Include(r => r.Floor.Building)
                .AsNoTracking()
                .OrderBy(r => r.RoomName)
                .ToListAsync();
        }
    }
}
