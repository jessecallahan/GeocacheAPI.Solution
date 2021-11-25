using System;
using System.Collections.Generic;

namespace GeocacheAPI.Responses
{
  public class GeocacheResponse
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public IEnumerable<ItemResponse> Items { get; set; }
  }

  public class ItemResponse
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  }
}