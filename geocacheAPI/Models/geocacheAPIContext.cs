using Microsoft.EntityFrameworkCore;

namespace GeocacheAPI.Models
{
  public class GeocacheAPIContext : DbContext
  {
    public virtual DbSet<Geocache> Geocaches { get; set; }
    public DbSet<Item> Items { get; set; }

    public GeocacheAPIContext(DbContextOptions options) : base(options) { }

    //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     {
    //       optionsBuilder.UseLazyLoadingProxies();
    //     }

  }
}