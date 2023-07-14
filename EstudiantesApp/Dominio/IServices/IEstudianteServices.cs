using EstudiantesApp.Transporte;

namespace EstudiantesApp.Dominio.IServices
{
    public interface IEstudianteServices
    {
        Task<List<EstudianteDto>> ConsultaEstudiante();
        Task<EstudianteDto> ConsultarEstudiante(int id);
        Task<bool> CrearEstudiante(EstudianteDto estudiante);
        Task<bool> EditarEstudiante(EstudianteDto estudiante);
        Task<bool> EliminarEstudiante(int id);
    }
}
