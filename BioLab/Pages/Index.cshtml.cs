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

        public static DateTime setMovieTime(int hour, int minute, int second)
        {

            DateTime s = DateTime.Now;
            TimeSpan ts = new TimeSpan(hour, minute, second);
            s = s.Date + ts;
            return s;
        }

        public static void Initialize(ConnectionContextDb context)
        {
            context.Movie.Add(new Movie
            {
                Id = new Guid(),
                MovieTitle = "The Hangover",
                MoviePoster = "/pictures/thehangover.jpeg",
                MoviePlot = "Two days before his wedding, Doug (Justin Bartha) and three friends (Bradley Cooper, Ed Helms, Zach Galifianakis) drive to Las Vegas for a wild and memorable stag party. " +
                            "In fact, when the three groomsmen wake up the next morning, they can't remember a thing; nor can they find Doug. " +
                            "With little time to spare, the three hazy pals try to re-trace their steps and find Doug so they can get him back to Los Angeles in time to walk down the aisle."
            });
            context.Movie.Add(new Movie
            {
                Id = new Guid(),
                MovieTitle = "Top Gun",
                MoviePoster = "/pictures/topgun.jpg",
                MoviePlot = "The Top Gun Naval Fighter Weapons School is where the best of the best train to refine their elite flying skills. " +
                            "When hotshot fighter pilot Maverick (Tom Cruise) is sent to the school, his reckless attitude and cocky demeanor put him at odds with the other pilots, " +
                            "especially the cool and collected Iceman (Val Kilmer). But Maverick isn't only competing to be the top fighter pilot, " +
                            "he's also fighting for the attention of his beautiful flight instructor, Charlotte Blackwood (Kelly McGillis)."
            });
            context.Movie.Add(new Movie
            {
                Id = new Guid(),
                MovieTitle = "Boondock Saints",
                MoviePoster = "/pictures/boondocksaints.jpg",
                MoviePlot = "Tired of the crime overrunning the streets of Boston, Irish Catholic twin brothers Conner (Sean Patrick Flanery) and Murphy (Norman Reedus) are inspired " +
                            "by their faith to cleanse their hometown of evil with their own brand of zealous vigilante justice. As they hunt down and kill one notorious gangster after another, " +
                            "they become controversial folk heroes in the community. But Paul Smecker (Willem Dafoe), an eccentric FBI agent, is fast closing in on their blood-soaked trail."
            });
            context.Movie.Add(new Movie
            {
                Id = new Guid(),
                MovieTitle = "Gladiator",
                MoviePoster = "/pictures/gladiator.jpg",
                MoviePlot = "Set in Roman times, the story of a once-powerful general forced to become a common gladiator. " +
                            "The emperor's son is enraged when he is passed over as heir in favour of his father's favourite general. He kills his father and arranges the murder of the general's family, " +
                            "and the general is sold into slavery to be trained as a gladiator - but his subsequent popularity in the arena threatens the throne."
            });
            context.SaveChanges();
            
            context.Showtime.Add(new Showtime 
            {
                Id = new Guid(),
                ShowtimeMovie = context.Movie.Where(m => m.MovieTitle == "Boondock Saints").FirstOrDefault(),
                NumOfSeats = 50,
                ShowtimeDate = setMovieTime(18, 00, 0)
            });
            context.Showtime.Add(new Showtime
            {
                Id = new Guid(),
                ShowtimeMovie = context.Movie.Where(m => m.MovieTitle == "Top Gun").FirstOrDefault(),
                NumOfSeats = 50,
                ShowtimeDate = setMovieTime(21, 00, 0)
            });
            context.Showtime.Add(new Showtime
            {
                Id = new Guid(),
                ShowtimeMovie = context.Movie.Where(m => m.MovieTitle == "Boondock Saints").FirstOrDefault(),
                NumOfSeats = 50,
                ShowtimeDate = setMovieTime(18, 00, 0).AddDays(1)
            });
            context.Showtime.Add(new Showtime
            {
                Id = new Guid(),
                ShowtimeMovie = context.Movie.Where(m => m.MovieTitle == "Top Gun").FirstOrDefault(),
                NumOfSeats = 50,
                ShowtimeDate = setMovieTime(21, 00, 0).AddDays(1)
            });
            context.SaveChanges();
        }
    }

}
