using System.ComponentModel.DataAnnotations;

namespace mba.apiref
{
    public partial class Email {
        [Key]
        public string email { get; set; }
        public string? type { get; set; }
        
    }
}