using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EstudiantesApp.Transporte
{
    public class EstudianteDto
    {
       
        public int Id { get; set; }

       
        [Display(Name = "Nombre(s) del alumno")]
        public string Nombre { get; set; }



        [Display(Name = "Apellido(s) del alumno")]
        public string Apellido { get; set; }


        [Display(Name = "Fecha de inscripcion")]
        public string FechaInscripcion { get; set; }
    }
}
