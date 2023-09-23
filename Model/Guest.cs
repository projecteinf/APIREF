using System.ComponentModel.DataAnnotations;

namespace mba.apiref
{
    public partial class Guest {
        [Key]
        public string DNI { get; set; }
        public string? Name { get; set; }
        public ICollection<Email>? Emails { get; set; }

        public ICollection<Event>? Events { get; set; }

        
    }
}