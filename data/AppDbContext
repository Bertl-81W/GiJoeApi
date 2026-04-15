using Microsoft.EntityFrameworkCore;
using GiJoeApi.Models;

namespace GiJoeApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}