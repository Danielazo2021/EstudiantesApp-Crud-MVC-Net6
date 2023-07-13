using EstudiantesApp.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using EstudiantesApp.Transporte;

namespace EstudiantesApp.Persistencia.Context
{
    public class AplicationDbContext: DbContext
    {

        public DbSet<Estudiante> Estudiante { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<EstudiantesApp.Transporte.EstudianteDto>? EstudianteDto { get; set; }


    }
}
