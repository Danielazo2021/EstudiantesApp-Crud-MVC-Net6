using EstudiantesApp.Transporte;

namespace EstudiantesApp.Dominio.IServices
{
    public interface IEstudianteServices
    {
        Task<List<EstudianteDto>> ConsultaEstudiante();
    }
}
