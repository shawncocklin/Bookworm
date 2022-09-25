using BookwormWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookwormWeb.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
