using Microsoft.EntityFrameworkCore;
using System;

namespace GeocacheAPI.Models
{
  public class GeocacheAPIContext : DbContext
  {
    public virtual DbSet<Geocache> Geocaches { get; set; }
    public DbSet<Item> Items { get; set; }

    public GeocacheAPIContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Item>()
          .HasData(
              new Item { Id = 1, Name = "Coins", GeocacheId = 1, IsActive = true, StartDate = DateTime.Now, EndDate = default },
              new Item { Id = 2, Name = "Jewelry", GeocacheId = 1, IsActive = true, StartDate = DateTime.Now, EndDate = default },
              new Item { Id = 3, Name = "Trading Stones", GeocacheId = 1, IsActive = true, StartDate = DateTime.Now, EndDate = default },
              new Item { Id = 4, Name = "Compass", GeocacheId = 2, IsActive = true, StartDate = DateTime.Now, EndDate = default },
              new Item { Id = 5, Name = "Poem", GeocacheId = 2, IsActive = true, StartDate = DateTime.Now, EndDate = default },
              new Item { Id = 6, Name = "Stamps", GeocacheId = 3, IsActive = false, StartDate = default, EndDate = DateTime.Now }
          );
      builder.Entity<Geocache>()
    .HasData(
        new Geocache { Id = 1, Name = "Treasure Island", Lat = 47.6062, Lng = 122.3321, Items = { } },
        new Geocache { Id = 2, Name = "Magic Mountain", Lat = 47.6062, Lng = 122.3321, Items = { } },
        new Geocache { Id = 3, Name = "Discovery Park", Lat = 47.6062, Lng = 122.3321, Items = { } }
    );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=app.db");
    }

  }
}