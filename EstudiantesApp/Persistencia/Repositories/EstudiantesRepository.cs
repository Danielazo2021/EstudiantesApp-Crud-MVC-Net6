using EstudiantesApp.Dominio.IRepositories;
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
                                         FechaInscripcion = t.FechaInscripcion.ToShortDateString()
                                     }).ToListAsync();
            return estudiantes;
                                    
        }
    }
}
