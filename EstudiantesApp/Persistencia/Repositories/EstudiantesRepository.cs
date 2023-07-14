using EstudiantesApp.Dominio.IRepositories;
using EstudiantesApp.Dominio.Models;
using EstudiantesApp.Persistencia.Context;
using EstudiantesApp.Transporte;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesApp.Persistencia.Repositories
{
    public class EstudiantesRepository : IEstudianteRepository
    {
        private readonly AplicationDbContext _context;
        public EstudiantesRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EstudianteDto>> ConsultaEstudiante()
        {
            var estudiantes = await (from t in _context.Estudiante
                                     select new EstudianteDto
                                     {
                                         Id = t.Id,
                                         Nombre = t.Nombre,
                                         Apellido = t.Apellido,
                                         FechaInscripcion = t.FechaInscripcion.ToShortDateString(),
                                         FechaDate= t.FechaInscripcion
                                     }).ToListAsync();
            return estudiantes;
                                    
        }

        public async Task<EstudianteDto> ConsultarEstudiante(int  id)
        {
            var estudiante = await (from t in _context.Estudiante
                                    where t.Id == id
                                    select new EstudianteDto
                                    {
                                        Id=t.Id,
                                        Nombre=t.Nombre,
                                        Apellido=t.Apellido,
                                        FechaInscripcion= t.FechaInscripcion.ToShortDateString(),
                                        FechaDate = t.FechaInscripcion
                                    }).FirstOrDefaultAsync();
            return estudiante;
        }

        public async Task<bool> CrearEstudiante(EstudianteDto estudianteFront)
        {


            try
            {
                var fecha = estudianteFront == null ? "" : estudianteFront.FechaInscripcion;
                var esCorrecto = DateTime.TryParse(fecha, out DateTime result);
                if (!esCorrecto) return false;

                var estudiante = new Estudiante
                {
                    FechaInscripcion = result,
                    Nombre = estudianteFront.Nombre,
                    Apellido = estudianteFront.Apellido
                };
                _context.Estudiante.Add(estudiante);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> EditarEstudiante(EstudianteDto estudianteFront)
        {
            try
            {
                var estudiante = await (from t in _context.Estudiante
                                        where t.Id == estudianteFront.Id
                                        select t).FirstOrDefaultAsync();
                if (estudiante == null) return false;

                var esCorrecto= DateTime.TryParse(estudianteFront.FechaInscripcion, out DateTime result);
                if(!esCorrecto) return false;

                estudiante.FechaInscripcion = result;
                estudiante.Nombre = estudianteFront.Nombre;
                estudiante.Apellido = estudianteFront.Apellido;

                await _context.SaveChangesAsync();
                return true;


            }
            catch(Exception)
            {
                return false;
            }
            
            
            
            
            
        }
    }
}
