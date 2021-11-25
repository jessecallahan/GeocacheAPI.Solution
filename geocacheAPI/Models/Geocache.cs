using System.Collections.Generic;

namespace GeocacheAPI.Models
{
  public class Geocache
  {

    public int Id { get; set; }
    public string Name { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public virtual ICollection<Item> Items { get; set; }
  }
}