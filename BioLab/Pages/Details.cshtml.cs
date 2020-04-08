using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BioLab
{
    public class DetailsModel : PageModel
    {
        private readonly BioLab.ConnectionContextDb _context;

        public DetailsModel(BioLab.ConnectionContextDb context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }
        public Showtime Showtime { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Showtime = await _context.Showtime.FirstOrDefaultAsync(s => s.Id == id);

            if (Showtime == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
