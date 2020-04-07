using Microsoft.EntityFrameworkCore;

namespace BioLab
{
    public class ConnectionContextDb : DbContext
    {
        public ConnectionContextDb(DbContextOptions<ConnectionContextDb> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Movie> Movie { get; set; }
    }
}