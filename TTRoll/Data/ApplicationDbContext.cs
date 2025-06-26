using Microsoft.EntityFrameworkCore;
using TTRoll.Models;

namespace TTRoll.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Character> Characters { get; set; }
    }
}
