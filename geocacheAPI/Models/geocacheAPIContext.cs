using Microsoft.EntityFrameworkCore;

namespace geocacheAPI.Models
{
    public class geocacheAPIContext : DbContext
    {
        public geocacheAPIContext(DbContextOptions<geocacheAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}