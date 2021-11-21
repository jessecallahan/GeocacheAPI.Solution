using System.Collections.Generic;

namespace geocacheAPI.Models
{
  public class Geocache 
  {
     public Geocache()
    {
      this.Items = new HashSet<Item>();
    }

    public int GeocacheId { get; set; }
    public string Name { get; set; }
    public string Coordinate { get; set; }
    public virtual ICollection<Item> Items { get; set; }
  }
}