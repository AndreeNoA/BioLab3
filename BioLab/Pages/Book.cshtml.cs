using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BioLab
{
    public class EditModel : PageModel
    {
        private readonly BioLab.ConnectionContextDb _context;

        public EditModel(BioLab.ConnectionContextDb context)
        {
            _context = context;
        }

       // [BindProperty]
       // public Movie Movie { get; set; }
        [BindProperty]

        public Showtime Showtime { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Showtime = await _context.Showtime.FirstOrDefaultAsync(m => m.Id == id);

            if (Showtime == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //
        //    _context.Attach(Showtime).State = EntityState.Modified;
        //
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ShowtimeExists(Showtime.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //
        //    return RedirectToPage("./Index");
        //}

        private bool ShowtimeExists(Guid id)
        {
            return _context.Showtime.Any(e => e.Id == id);
        }
    }
}
