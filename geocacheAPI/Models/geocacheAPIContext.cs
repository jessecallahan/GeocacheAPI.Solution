using Microsoft.EntityFrameworkCore;

namespace geocacheAPI.Models
{
  public class geocacheAPIContext : DbContext
  {
    public virtual DbSet<Geocache> Geocaches { get; set; }
    public  DbSet<Item> Items { get; set; }
  
    public geocacheAPIContext(DbContextOptions options) : base(options) { }

//  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     {
//       optionsBuilder.UseLazyLoadingProxies();
//     }

  }
}