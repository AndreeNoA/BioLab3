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
    public class BookingModel : PageModel
    {
        private readonly ConnectionContextDb _context;

        public BookingModel(ConnectionContextDb context)
        {
            _context = context;
        }

        [BindProperty]
        public Showtime Showtime { get; set; }

        public async Task OnGet(Guid? id)
        {
            Showtime = await _context.Showtime.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var movieFromDb = await _context.Showtime.FindAsync(Showtime.Id);
                movieFromDb.NumberOfBookedSeats += Showtime.NumberOfBookedSeats;

                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
