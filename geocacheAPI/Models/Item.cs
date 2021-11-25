using System;
using System.ComponentModel.DataAnnotations;

namespace GeocacheAPI.Models
{
  public class Item
  {
    public int Id { get; set; }
    [MaxLength(500)]
    public string Name { get; set; }
    public int GeocacheId { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  }
}