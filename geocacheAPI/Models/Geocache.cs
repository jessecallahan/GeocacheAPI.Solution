using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeocacheAPI.Models
{
  public class Geocache
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public double Lat { get; set; }
    [Required]
    public double Lng { get; set; }
    public virtual ICollection<Item> Items { get; set; }
  }
}