using System.ComponentModel.DataAnnotations;

namespace CrudCannia.Models
{
    public class Propietario
    {
        [Key]
        public int IdPropietario { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;
    }
}
