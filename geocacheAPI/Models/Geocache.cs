using System.Collections.Generic;
using Newtonsoft.Json;

namespace geocacheAPI.Models
{
  public class Geocache 
  {
    //  public Geocache()
    // {
    //   this.Items = new HashSet<Item>();
    // }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Coordinate { get; set; }
    public virtual ICollection<Item> Items { get; set; }
  }
}