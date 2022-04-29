using System.ComponentModel.DataAnnotations;

namespace PASVE.Models
{
    public class Credentials
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
