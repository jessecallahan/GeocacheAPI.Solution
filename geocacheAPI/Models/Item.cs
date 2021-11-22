using System.ComponentModel.DataAnnotations;

namespace geocacheAPI.Models
{
    public class Item
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
        public int GeocacheId { get; set; }
        public virtual Geocache Geocache { get; set; }
        public bool IsActive { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}