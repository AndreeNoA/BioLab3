using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BioLab
{
    public class IndexModel : PageModel
    {
        private readonly BioLab.ConnectionContextDb _context;

        public IndexModel(BioLab.ConnectionContextDb context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }

        public IActionResult OnGetSeed()
        {
            Initialize(_context);
            return RedirectToPage("./Index");
        }

        public static void Initialize(ConnectionContextDb context)
        {
            context.Movie.Add(new Movie
            {
                Id = new Guid(),
                Title = "The Hangover",
                ImageLink = "https://upload.wikimedia.org/wikipedia/en/thumb/b/b9/Hangoverposter09.jpg/220px-Hangoverposter09.jpg"
            });
            context.Movie.Add(new Movie
            {
                Id = new Guid(),
                Title = "Top Gun",
                ImageLink = "https://en.wikipedia.org/wiki/File:Top_Gun_Movie.jpg"
            });
            context.SaveChanges();
        }
    }

}
