// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace GeocacheAPI.Models
// {
//   public class DataGenerator
//   {

//     public static void Initialize(IServiceProvider serviceProvider)
//     {
//       using (var context = new GeocacheAPIContext(
//           serviceProvider.GetRequiredService<DbContextOptions<GeocacheAPIContext>>()))
//       {
//         // Look for any board games already in database.
//         if (context.Geocaches.Any())
//         {
//           return;   // Database has been seeded
//         }

//         // context.Items.AddRange(
//         //   new Item { Id = 1, Name = "Coins", GeocacheId = 1, IsActive = true, StartDate = DateTime.Now, EndDate = default },
//         //       new Item { Id = 2, Name = "Jewelry", GeocacheId = 1, IsActive = true, StartDate = DateTime.Now, EndDate = default },
//         //       new Item { Id = 3, Name = "Trading Stones", GeocacheId = 1, IsActive = true, StartDate = DateTime.Now, EndDate = default },
//         //       new Item { Id = 4, Name = "Compass", GeocacheId = 2, IsActive = true, StartDate = DateTime.Now, EndDate = default },
//         //       new Item { Id = 5, Name = "Poem", GeocacheId = 2, IsActive = true, StartDate = DateTime.Now, EndDate = default },
//         //       new Item { Id = 6, Name = "Stamps", GeocacheId = 3, IsActive = false, StartDate = default, EndDate = DateTime.Now }
//         // );

//         context.Geocaches.AddRange(
//            new Geocache { Id = 1, Name = "Treasure Island", Lat = 47.6062, Lng = 122.3321, Items = { } },
//         new Geocache { Id = 2, Name = "Magic Mountain", Lat = 47.6062, Lng = 122.3321, Items = { } },
//         new Geocache { Id = 3, Name = "Discovery Park", Lat = 47.6062, Lng = 122.3321, Items = { } }
//                         );
//         context.SaveChanges();
//       }
//     }
//   }
// }