using System.ComponentModel.DataAnnotations;

namespace CrudCannia.Models
{
    public class Mascota
    {
        [Key]
        public int IdMascota { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        public string? Especie { get; set; }
        public string? Raza { get; set; }
        public int? Edad { get; set; }
        public string? Sexo { get; set; }
    }
}

