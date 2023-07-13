using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudiantesApp.Dominio.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar(80)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(80)")]
        public string Apellido { get; set; }

        [Required]
        public DateTime FechaInscripcion { get; set; }
    }
}
