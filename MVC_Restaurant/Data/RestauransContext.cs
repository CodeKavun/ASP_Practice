using Microsoft.EntityFrameworkCore;
using MVC_Restaurant.Model;

namespace MVC_Restaurant.Data
{
    public class RestauransContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        public RestauransContext(DbContextOptions options) : base(options)
        {
        }
    }
}
