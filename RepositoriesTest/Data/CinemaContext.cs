using Microsoft.EntityFrameworkCore;
using RepositoriesTest.Models;

namespace RepositoriesTest.Data
{
    public class CinemaContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public CinemaContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
