using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BioLab
{
    public class CreateModel : PageModel
    {
        private readonly BioLab.ConnectionContextDb _context;

        public CreateModel(BioLab.ConnectionContextDb context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        //public IActionResult Seed()
        //{
        //    Initialize(_context);
        //    return RedirectToAction("./Privacy");
        //}
        //
        //public static void Initialize(ConnectionContextDb context)
        //{
        //    context.Movie.Add(new Movie
        //    {
        //        Id = new Guid(),
        //        Title = "The Hangover",
        //        ImageLink = "https://upload.wikimedia.org/wikipedia/en/thumb/b/b9/Hangoverposter09.jpg/220px-Hangoverposter09.jpg"
        //    });
        //    context.Movie.Add(new Movie
        //    {
        //        Id = new Guid(),
        //        Title = "Top Gun",
        //        ImageLink = "https://en.wikipedia.org/wiki/File:Top_Gun_Movie.jpg"
        //    });
        //    context.SaveChanges();
        //}
    }
}
