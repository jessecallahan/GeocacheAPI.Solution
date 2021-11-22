using System;
using System.Collections.Generic;

namespace geocacheAPI.Responses
{
    public class GeocacheResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coordinate { get; set; }
        public IEnumerable<ItemResponse> Items { get; set; } 
            // = Array.Empty<ItemResponse>();
    }

    public class ItemResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
          public bool IsActive { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}