using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demosite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace demosite.Pages.Rooms
{
    public class prepopulatebasePageModel : PageModel
    {
        public SelectList FloorIDSL { get; set; }
        public void PopulateDropDownList(demositeContext _context,
            object selectedFloorID = null)
        {
            var FloorIDquery = from f in _context.Floor
                               orderby f.FloorID
                               select f;
            FloorIDSL = new SelectList(FloorIDquery.AsNoTracking(),
                "FloorID", "FloorID", selectedFloorID);
        }
    }
}
