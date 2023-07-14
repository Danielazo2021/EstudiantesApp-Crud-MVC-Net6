using EstudiantesApp.Transporte;

namespace EstudiantesApp.Dominio.IRepositories
{
    public interface IEstudianteRepository
    {
        Task<List<EstudianteDto>> ConsultaEstudiante();
        Task<EstudianteDto> ConsultarEstudiante(int id);
        Task<bool> CrearEstudiante(EstudianteDto estudiante);
        Task<bool> EditarEstudiante(EstudianteDto estudiante);
    }
}
