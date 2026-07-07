using Lab_08_Web_API_With_Migration.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_08_Web_API_With_Migration.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();
    }
}
