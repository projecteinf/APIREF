using System.ComponentModel.DataAnnotations;

namespace mba.apiref
{
    public partial class Event {
        [Key]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public ICollection<Guest>? Guests { get; set; }
        
    }
}