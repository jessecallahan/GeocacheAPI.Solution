using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeocacheAPI.Models
{
  public class Item
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public int GeocacheId { get; set; }
    [JsonIgnore]
    public virtual Geocache Geocache { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  }
}